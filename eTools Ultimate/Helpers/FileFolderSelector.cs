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
            return path;
        }
        public static string? SelectFile(string? path, string? title = null)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                ValidateNames = true,
                CheckFileExists = true
            };
            if (File.Exists(path))
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(path);
                fileDialog.FileName = Path.GetFileName(path);
            }
            if (title != null)
                fileDialog.Title = title;
            if (fileDialog.ShowDialog() == true)
                return fileDialog.FileName;
            return path;
        }
    }
}
