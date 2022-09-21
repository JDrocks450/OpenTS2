﻿/*
 * This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
 * If a copy of the MPL was not distributed with this file, You can obtain one at
 * http://mozilla.org/MPL/2.0/. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTS2.Content.Interfaces;
using OpenTS2.Files;

namespace OpenTS2.Content
{
    /// <summary>
    /// Manages the game's asset saving/loading/caching and its filesystem.
    /// </summary>
    public class ContentManager
    {
        protected static ContentManager _singleton;
        protected Filesystem _fileSystem;
        protected ContentProvider _provider;
        protected ITextureFactory _textureFactory;
        public static ContentManager Get
        { get
            {
                return _singleton;
            } 
        }
        public Filesystem FileSystem
        {
            get
            {
                return _fileSystem;
            }
        }
        public ContentProvider Provider
        {
            get
            {
                return _provider;
            }
        }
        public ITextureFactory TextureFactory
        {
            get
            {
                return _textureFactory;
            }
        }
        public ContentManager()
        {
            _singleton = this;
        }
        public ContentCache Cache
        {
            get
            {
                return _provider.Cache;
            }
        }

        public ContentChanges Changes
        {
            get
            {
                return _provider.Changes;
            }
        }
    }
}
