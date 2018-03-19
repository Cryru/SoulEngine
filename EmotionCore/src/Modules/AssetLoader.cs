﻿// Emotion - https://github.com/Cryru/Emotion

#region Using

using System;
using System.Collections.Generic;
using System.IO;
using Emotion.Objects;

#endregion

namespace Emotion.Modules
{
    public class AssetLoader
    {
        #region Declarations

        private Context _context;
        private Dictionary<string, Texture> _loadedTextures;

        /// <summary>
        /// The root directory in which assets are located.
        /// </summary>
        public string RootDirectory;

        #endregion

        public AssetLoader(Context context)
        {
            _context = context;
            _loadedTextures = new Dictionary<string, Texture>();
        }

        #region Texture

        /// <summary>
        /// Loads a texture.
        /// </summary>
        /// <param name="path">The path of the texture image to load.</param>
        public Texture LoadTexture(string path)
        {
            // Load the bytes of the file.
            byte[] data = File.ReadAllBytes(PathToCrossPlatform(path));
            // Add it to the list of loaded textures.
            _loadedTextures.Add(PathToEnginePath(path), new Texture(_context, data));

            // Return the just loaded texture.
            return GetTexture(path);
        }

        /// <summary>
        /// Returns a loaded texture.
        /// </summary>
        /// <param name="path">The path of the loaded texture.</param>
        /// <returns>A loaded texture.</returns>
        public Texture GetTexture(string path)
        {
            return _loadedTextures[PathToEnginePath(path)];
        }

        #endregion

        #region Other

        /// <summary>
        /// Returns the contents of a custom file.
        /// </summary>
        /// <param name="path">The path to the file to load.</param>
        public byte[] GetFile(string path)
        {
            // Load the bytes of the file.
            return File.ReadAllBytes(PathToCrossPlatform(path));
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Converts the provided path to an engine universal format,
        /// </summary>
        /// <param name="path">The path to convert.</param>
        /// <returns>The converted path.</returns>
        private static string PathToEnginePath(string path)
        {
            return path.Replace('/', '$').Replace('\\', '$').Replace('$', '/');
        }

        /// <summary>
        /// Converts the provided path to the current platform's path signature.
        /// </summary>
        /// <param name="path">The path to convert.</param>
        /// <returns>The converted path.</returns>
        private string PathToCrossPlatform(string path)
        {
            return RootDirectory + Path.DirectorySeparatorChar + path.Replace('/', '$').Replace('\\', '$').Replace('$', Path.DirectorySeparatorChar);
        }

        #endregion
    }
}