using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace zip_folder_console_app
{
    public class ZipServer
    {
        public void Zip(string source, string destination, string[] excludedExtensions, string[] excludedDirectories, string[] excludedFiles)
        {
            using (ZipFile zip = new ZipFile { CompressionLevel = CompressionLevel.BestCompression })
            {
                var filesList = Directory.GetFiles(source, "*", SearchOption.AllDirectories);

                var rejectedFiles = filesList.
                    Where(f => 
                    excludedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant())
                    // || excludedDirectories.Contains(new DirectoryInfo(Path.GetDirectoryName(f)).Name) 
                    || (excludedDirectories.Length > 0 ? new DirectoryInfo(Path.GetDirectoryName(f)).FullName.Contains(string.Format(@"\{0}", excludedDirectories)) : false)
                    || excludedFiles.Contains(Path.GetFileNameWithoutExtension(f))).ToArray();
               
                var filteredFiles = filesList.Except(rejectedFiles);

                foreach (var f in filteredFiles)
                {
                    zip.AddFile(f, GetCleanFolderName(source, f));
                }

                var destinationFilename = Directory.GetParent(source) + @"\" + destination;

                if (Directory.Exists(destinationFilename) && !destinationFilename.EndsWith(".zip"))
                {
                    destinationFilename += $"\\{new DirectoryInfo(source).Name}-{DateTime.Now:yyyy-MM-dd-HH-mm-ss-ffffff}.zip";
                }

                zip.Save(destinationFilename);
            }
        }

        private string GetCleanFolderName(string source, string filepath)
        {
            var a = new DirectoryInfo(Path.GetDirectoryName(filepath)).Name;
            var result = filepath.Substring(source.Length);

            if (result.StartsWith("\\"))
            {
                result = result.Substring(1);
            }

            result = result.Substring(0, result.Length - new FileInfo(filepath).Name.Length);

            return result;
        }
    }
}
