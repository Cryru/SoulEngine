﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulEngine.Objects;
using Soul.IO;
using SoulEngine.Objects.Components.Helpers;
using Microsoft.Xna.Framework.Audio;
using System.Threading;

namespace SoulEngine.Modules
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Manages asset integrity.
    /// </summary>
    public class AssetManager : IModule
    {
        #region Global Assets
        /// <summary>
        /// The texture loaded when an asset can't be found or loaded.
        /// </summary>
        public static Texture2D MissingTexture;
        /// <summary>
        /// A blank texture.
        /// </summary>
        public static Texture2D BlankTexture;
        /// <summary>
        /// The default font.
        /// </summary>
        public static SpriteFont DefaultFont;
        #endregion

        #region Instance Data
        /// <summary>
        /// The path to the assets meta file.
        /// </summary>
        private string assetsMetaPath = "Content" + Path.DirectorySeparatorChar + "meta.soul";
        /// <summary>
        /// The assets meta file.
        /// </summary>
        public MFile metaSoul;
        #endregion

        /// <summary>
        /// Loads global assets used throughout the engine.
        /// </summary>
        public bool Initialize()
        {
            try
            {
                // Load the missingtexture.
                MissingTexture = Context.Core.Content.Load<Texture2D>("Engine/missing");

                // Load the default font.
                DefaultFont = Context.Core.Content.Load<SpriteFont>("Font/Default");

                // Generate a blank texture for solid colors.
                BlankTexture = new Texture2D(Context.Graphics, 1, 1);
                Color[] data = new Color[] { Color.White };
                BlankTexture.SetData(data);
                BlankTexture.Name = "Engine/blank";
            }
            catch (Exception)
            {
                Context.Core.Module<ErrorManager>().RaiseError("Couldn't load global assets.", 240);
                return false;
            }

            // Load text object tags.
            TagFactory.Initialize();

            // Load assets meta file.
            if (Settings.EnforceAssetIntegrity)
            {
                /*
                 * The meta.soul file is expected to a Soul Managed File with each key being a
                 * file path relative to the Content folder and each value a hash of the file, 
                 * as hashed by SoulLib. If encrypted the key from the settings file is used.
                 */
                if (!File.Exists(assetsMetaPath))
                {
                    Context.Core.Module<ErrorManager>().RaiseError("The meta.soul file is missing.", 241);
                    return false;
                }

                string AssetMeta = Utils.ReadFile(assetsMetaPath);

                if (Utils.ReadFile(assetsMetaPath) == "")
                {
                    Context.Core.Module<ErrorManager>().RaiseError("The meta.soul file is not formatted correctly.", 242);
                    return false;
                }

                if (Soul.Encryption.MD5(AssetMeta) != Settings.MetaMD5)
                {
                    Context.Core.Module<ErrorManager>().RaiseError("The meta.soul hash is invalid.", 243);
                    return false;
                }

                AssetMeta = "";

                // Load the meta file as a Soul managed file.
                metaSoul = new MFile(assetsMetaPath, null, Settings.SecurityKey);
            }

            return true;
        }

        #region Asset Loading
        /// <summary>
        /// Loads a texture asset into the current scene's content manager and returns it.
        /// </summary>
        /// <param name="textureName">Path and name of the asset, root is the Content folder.</param>
        /// <returns>The texture, or the default texture if not found.</returns>
        public static Texture2D Texture(string textureName)
        {
            return Asset(textureName, MissingTexture);
        }

        /// <summary>
        /// Loads a font into the current scene's content manager and returns it.
        /// </summary>
        /// <param name="fontName">Path and name of the asset, root is the Content folder.</param>
        /// <returns>The texture, or the default font if not found.</returns>
        public static SpriteFont Font(string fontName)
        {
            return Asset(fontName, DefaultFont);
        }

        /// <summary>
        /// Loads a sound asset into the current scene's content manager and returns it.
        /// </summary>
        /// <param name="soundName">Path and name of the asset, root is the Content folder.</param>
        /// <returns>The sound, or the nothing if not found.</returns>
        public static SoundEffect Sound(string soundName)
        {
            return Asset<SoundEffect>(soundName, null);
        }

        /// <summary>
        /// Loads a custom asset file and returns its contents.
        /// </summary>
        /// <param name="fileName">Path and name including extension of the asset, root is the Content folder.</param>
        /// <returns>A string containing the contents of the file.</returns>
        public static string CustomFile(string fileName)
        {
            //Check if the file exists.
            if (!AssetExist(fileName, "")) return "";

            //If it does read it and return it.
            return Utils.ReadFile("Content" + Path.DirectorySeparatorChar + fileName);
        }

        /// <summary>
        /// Loads an asset into the current scene's content manager and returns it, or a specified asset if missing.
        /// </summary>
        /// <typeparam name="T">The type of asset to load</typeparam>
        /// <param name="assetName">Path and name of the asset, root is the Content folder.</param>
        /// <param name="ifMissing">The asset to load if the requested asset is missing.</param>
        /// <returns>The asset requested, or the replacement if missing.</returns>
        public static T Asset<T>(string assetName, T ifMissing)
        {
            if (AssetExist(assetName))
                if (Context.Core.Scene == null)
                    return Context.Core.Content.Load<T>(assetName);
                else
                    return Context.Core.Scene.Assets.Content.Load<T>(assetName);
            else
                return ifMissing;
        }
        #endregion

        /// <summary>
        /// Checks whether the requested asset exists.
        /// </summary>
        /// <param name="name">Path and name of the asset, root is the Content folder.</param>
        /// <param name="extension">The extension of the file we are looking for.</param>
        public static bool AssetExist(string name, string extension = ".xnb")
        {
            // Convert the asset path to a platform agnostic file path.
            name = Path.Combine("Content", 
                name.Replace('/', '@').Replace('\\', '@').Replace('@', Path.DirectorySeparatorChar) + extension);

            // Check if the file exists.
            if (File.Exists(name))
            {
                // Check if an asset meta file has been loaded.
                if (Settings.EnforceAssetIntegrity &&
                    Context.Core.isModuleLoaded<AssetManager>() &&
                    Context.Core.Module<AssetManager>().metaSoul != null)
                {
                    // Get the asset's hash.
                    string expectedHash = Context.Core.Module<AssetManager>().metaSoul.Content<string>(name);

                    // Hash the asset.
                    string actualHash = Soul.Encryption.MD5(Utils.ReadFile(name));

                    // Check if the hashes match, and if not raise an error, and return false.
                    if (expectedHash != actualHash)
                    {
                        Context.Core.Module<ErrorManager>().RaiseError("File hash doesn't match: " + name, 244);
                        return false;
                    }
                }

                // If no hash checking is required, the file exists.
                return true;
            }

            // The file doesn't exist.
            return false;
        }

    }
}