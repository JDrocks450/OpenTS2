using System;
using System.Collections.Generic;
using System.IO;
using OpenTS2.Common;
using OpenTS2.Content;
using OpenTS2.Content.DBPF;
using OpenTS2.Files.Utils;
using UnityEngine;

namespace OpenTS2.Files.Formats.DBPF
{
    /// <summary>
    /// Codec for what is known in game as cEdithObjectModule. Likely a container for different types of objects.
    /// </summary>
    [Codec(TypeIDs.OBJM)]
    public class ObjectModuleCodec : AbstractCodec
    {
        public override AbstractAsset Deserialize(byte[] bytes, ResourceKey tgi, DBPFFile sourceFile)
        {
            var stream = new MemoryStream(bytes);
            var reader = IoBuffer.FromStream(stream, ByteOrder.LITTLE_ENDIAN);

            // Skip first 64 bytes.
            reader.Seek(SeekOrigin.Begin, 64);

            // First int, ignored.
            reader.Seek(SeekOrigin.Current, 4);
            // Version number.
            int version = reader.ReadInt32();
            Debug.Log($"Version: 0x{version:X}");
            // Type identifier.
            uint type = reader.ReadUInt32();
            if (type != 0x4F626A4D)
            {
                // Corresponds to the string "ObjM"
                throw new NotImplementedException("ObjM file does not have `ObjM` magic bytes");
            }

            var objectIdToSaveType = new Dictionary<int, int>();
            // Next is the number of objects.
            var numObjects = reader.ReadInt32();
            for (var i = 0; i < numObjects; i++)
            {
                // Data attribute 0x13, might be object id.
                int dataAttr = reader.ReadInt32();
                int objectSaveType = reader.ReadInt32();
                objectIdToSaveType[dataAttr] = objectSaveType;
            }

            return new ObjectModuleAsset(version: version, objectIdToSaveType: objectIdToSaveType);
        }
    }
}