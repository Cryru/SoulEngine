﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulEngine.Objects;

namespace SoulEngine
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Manages asset integrity.
    /// </summary>
    static class AssetManager
    {
        #region "Global Assets"
        /// <summary>
        /// The texture loaded when an asset can't be found or loaded.
        /// </summary>
        public static Texture2D MissingTexture;
        /// <summary>
        /// A blank texture.
        /// </summary>
        public static Texture2D BlankTexture;
        #endregion

        /// <summary>
        /// Loads global assets used throughout the engine.
        /// </summary>
        public static void LoadGlobal()
        {
            //Load the missingtexture.
            MissingTexture = Context.Core.Content.Load<Texture2D>("Engine/missing");

            /*
             * Generate the blank texture by creating a new 1 by 1 texture and
             * inserting white color into it.
             */
            BlankTexture = new Texture2D(Context.Graphics, 1, 1);
            Color[] data = new Color[] { Color.White };
            BlankTexture.SetData(data);
            BlankTexture.Name = "Engine/blank";
        }

        /// <summary>
        /// Loads a texture asset into the current scene's content manager and returns it.
        /// </summary>
        /// <param name="textureName">Path and name of the asset, root is the Content folder.</param>
        /// <returns>The texture, or the missingtexture if not found.</returns>
        public static Texture2D Texture(string textureName)
        {
            if (GetAssetExist(textureName))
                if (Context.Core.Scene != null)
                    return Context.Core.Content.Load<Texture2D>(textureName);
                else
                    return Context.Core.Scene.Assets.Content.Load<Texture2D>(textureName);
            else
                return MissingTexture;
        }

        /// <summary>
        /// Returns whether the requested asset exists.
        /// </summary>
        /// <param name="name">The path to the asset file relative to the Content folder.</param>
        public static bool GetAssetExist(string name)
        {
            //Assign the path of the file.
            string contentpath = "Content\\" + name.Replace("/", "\\") + ".xnb";
            //Check if the file exists.
            if (File.Exists(contentpath))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reads the assets meta file, and applies checks for validity.
        /// If true is returned then files are as they should be, otherwise false is returned.
        /// Format: Asset Meta Generator Version 3
        /// </summary>
        public static bool AssertAssets()
        {
            /*
             * The meta.soul file is expected to be in a JSON format where the keys are the
             * file paths relative to the Content folder and the value is the hash of the file, 
             * as hashed by SoulLib. If encrypted the key from the settings file is used.
             */

            MFile file = new MFile("Content\\meta.soul");

            try
            {
                //Iterate through each file.
                for (int i = 0; i < file.Content.Keys.Count; i++)
                {
                    //Get the path of the file.
                    string path = file.Content.Keys.ToArray()[i];
                    //Get the hash of the current file.
                    string currentFile = Soul.Encryption.GetMD5("Content\\" + path);
                    //Check against the meta stored hash, if it doesn't match return false.
                    if (currentFile != (string) file.Content[path]) return false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Corrupt meta.soul data.");
            }

            //If everything went smoothly, return true.
            return true;
        }
    }
}
