﻿#region Using

using System;
using System.IO;
using System.Linq;
using Emotion.Common;
using Emotion.IO;
using Emotion.Standard.Logging;

#endregion

namespace Emotion.Platform.Implementation.CommonDesktop
{
    /// <inheritdoc />
    public class FileAssetSource : AssetSource
    {
        /// <summary>
        /// The folder assets will be read from.
        /// </summary>
        public string Folder { get; protected set; }

        /// <summary>
        /// The folder on the file system, as opposed to how it is represented in the AssetLoader.
        /// </summary>
        protected string _folderFs;

        /// <inheritdoc />
        /// <summary>
        /// The folder relative to the executable where file assets will be loaded from.
        /// </summary>
        /// <param name="folder">The folder to load assets from.</param>
        /// <param name="includeFolderInManifest">Whether to include the source's folder in the asset paths. Off by default.</param>
        public FileAssetSource(string folder, bool includeFolderInManifest = false)
        {
            Folder = folder;
            _folderFs = Path.Join(".", folder);

            // Check if folder exists.
            if (!Directory.Exists(_folderFs)) Directory.CreateDirectory(_folderFs);
            PopulateInternalManifest(includeFolderInManifest);
        }

        protected void PopulateInternalManifest(bool includeFolder)
        {
            InternalManifest.Clear();
            string[] files = Directory.GetFiles(_folderFs, "*", SearchOption.AllDirectories);
            for (var i = 0; i < files.Length; i++)
            {
                string file = files[i];
                InternalManifest.TryAdd(FilePathToEnginePath(file, includeFolder), file);
            }
        }

        /// <inheritdoc />
        public override byte[] GetAsset(string enginePath)
        {
            // Convert to file path.
            bool found = InternalManifest.TryGetValue(enginePath, out string filePath);

            // Check if found.
            if (!found) return new byte[0];

            // Check if exists.
            if (File.Exists(filePath)) return File.ReadAllBytes(filePath);

            Engine.Log.Error($"Couldn't read asset {enginePath} with file path {filePath}.", MessageSource.AssetLoader);
            return new byte[0];
        }

        /// <inheritdoc />
        public override DateTime GetAssetModified(string enginePath)
        {
            // Convert to file path.
            bool found = InternalManifest.TryGetValue(enginePath, out string filePath);

            // Check if found.
            if (!found) return base.GetAssetModified(enginePath);

            // The API actually allows for a file to be modified before it was created. lol
            DateTime lastWrite = File.GetLastWriteTimeUtc(filePath);
            DateTime creationTime = File.GetCreationTimeUtc(filePath);
            int later = DateTime.Compare(lastWrite, creationTime);

            return later > 0 ? lastWrite : creationTime;
        }

        /// <summary>
        /// Convert a file path of any type to an engine path.
        /// </summary>
        /// <param name="filePath">The file path to convert.</param>
        /// <param name="keepFolder">Whether to keep the folder in the path.</param>
        /// <returns>The engine path corresponding to the specified file path.</returns>
        protected virtual string FilePathToEnginePath(string filePath, bool keepFolder = false)
        {
            filePath = filePath.Replace(_folderFs + Path.DirectorySeparatorChar, "");
            if (keepFolder) filePath = AssetLoader.JoinPath(Folder, filePath);
            return AssetLoader.NameToEngineName(filePath);
        }

        public override string ToString()
        {
            return $".Net System.IO @ {_folderFs}";
        }
    }
}