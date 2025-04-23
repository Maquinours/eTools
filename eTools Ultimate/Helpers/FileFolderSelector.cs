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
        public static string SelectFolder(string? path, string? title = null)
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
    }
}
