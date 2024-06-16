﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTS2.Lua.Disassembly.OpCodes
{
    public class TEST : LuaC50.OpCode
    {
        public override void Disassemble(LuaC50.Context context)
        {
            if (C == 0)
                context.Code.WriteLine($"if not {context.R(B)} then");
            else
                context.Code.WriteLine($"if ({context.R(B)} == {C}) then");
            context.Code.Indentation++;
            context.Code.WriteLine($"{context.R(A)} = {context.R(B)}");
            context.Code.Indentation--;
            context.Code.WriteElse();
            context.Code.Indentation++;
            var jLabel = context.MakeRelativeJump(2);
            context.Code.WriteGoto(jLabel);
            context.Code.Indentation--;
            context.Code.WriteEnd();
        }
    }
}
