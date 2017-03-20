using DarkExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkExplorer.Models
{
    public class DirectoryFileInfo : IDirectoryFileInfo
    {
        private string currentPath;

        public bool IsFile { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public IDirectoryFileInfo Parent { get; set; }


        public DirectoryFileInfo(DirectoryInfo directoryInfo)
        {
            Init(directoryInfo);
        }

        private void Init(DirectoryInfo directoryInfo)
        {
            IsFile = false;
            Name = directoryInfo.Name;
            FullName = directoryInfo.FullName;
            if (directoryInfo.Parent != null)
            {
                Parent = new DirectoryFileInfo(directoryInfo.Parent);
            }
        }

        public DirectoryFileInfo(FileInfo fileInfo)
        {
            Init(fileInfo);
        }

        private void Init(FileInfo fileInfo)
        {
            IsFile = true;
            Name = fileInfo.Name;
            FullName = fileInfo.FullName;
            if (fileInfo.Directory != null)
            {
                Parent = new DirectoryFileInfo(fileInfo.Directory);
            }
        }

        public DirectoryFileInfo(string currentPath)
        {
            if (Directory.Exists(currentPath))
            {
                DirectoryInfo di = new DirectoryInfo(currentPath);
                Init(di);
            }
            else
            {

                FileInfo fi = new FileInfo(currentPath);
                Init(fi);
            }
        }
    }
}
