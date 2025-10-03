using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Helpers
{
    internal class FileFolderSelector
    {
        public static string? SelectFolder(string? path, string? title = null)
        {
            OpenFolderDialog folderDialog = new OpenFolderDialog()
            {
                ValidateNames = true
            };
            if(Directory.Exists(path))
                folderDialog.InitialDirectory = Path.GetDirectoryName(path);
            if(title != null)
                folderDialog.Title = title;
            if (folderDialog.ShowDialog() == true)
                return folderDialog.FolderName;

            return null;
        }
        public static string? SelectFile(string? path, string? title = null, string? filter = null)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                ValidateNames = true,
                CheckFileExists = true
            };

            string? initialDirectoryPath = Path.GetDirectoryName(path);
            if (File.Exists(path))
            {
                fileDialog.InitialDirectory = initialDirectoryPath;
                fileDialog.FileName = Path.GetFileName(path);
            }
            else if(Directory.Exists(path))
            {
                fileDialog.InitialDirectory = initialDirectoryPath;
            }

            if (title != null)
                fileDialog.Title = title;
            if (filter != null)
                fileDialog.Filter = filter;

            if (fileDialog.ShowDialog() == true)
                return fileDialog.FileName;

            return null;
        }
    }
}
