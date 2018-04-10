﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace Emotion.Platform.Assets
{
    public class Loader
    {
        #region Declarations

        private Context _context;
        private Dictionary<string, Texture> _loadedTextures;
        private Dictionary<string, Font> _loadedFonts;

        /// <summary>
        /// The root directory in which assets are located.
        /// </summary>
        public string RootDirectory;

        #endregion

        public Loader(Context context)
        {
            _context = context;
            _loadedTextures = new Dictionary<string, Texture>();
            _loadedFonts = new Dictionary<string, Font>();
        }

        #region Texture

        /// <summary>
        /// Loads a texture.
        /// </summary>
        /// <param name="path">An engine path to the texture to load.</param>
        public Texture LoadTexture(string path)
        {
            string parsedPath = PathToCrossPlatform(path);

            if (!File.Exists(parsedPath))
            {
                throw new Exception("The file " + parsedPath + " could not be found.");
            } 

            // Load the bytes of the file.
            byte[] data = File.ReadAllBytes(parsedPath);
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

        #region Font

        /// <summary>
        /// Loads a font.
        /// </summary>
        /// <param name="path">An engine path to the font to load.</param>
        public Font LoadFont(string path)
        {
            string parsedPath = PathToCrossPlatform(path);

            if (!File.Exists(parsedPath))
            {
                throw new Exception("The file " + parsedPath + " could not be found.");
            }

            // Load the bytes of the file.
            byte[] data = File.ReadAllBytes(parsedPath);
            // Add it to the list of loaded fonts.
            _loadedFonts.Add(PathToEnginePath(path), new Font(data));

            // Return the just loaded font.
            return GetFont(path);
        }

        /// <summary>
        /// Returns a loaded font.
        /// </summary>
        /// <param name="path">The path of the loaded font.</param>
        /// <returns>A loaded font.</returns>
        public Font GetFont(string path)
        {
            return _loadedFonts[PathToEnginePath(path)];
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

#endif