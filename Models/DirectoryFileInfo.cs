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
        public bool IsFile { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }


        public DirectoryFileInfo(DirectoryInfo directoryInfo)
        {
            IsFile = false;
            Name = directoryInfo.Name;
            FullName = directoryInfo.FullName;
        }

        public DirectoryFileInfo(FileInfo fileInfo)
        {
            IsFile = true;
            Name = fileInfo.Name;
            FullName = fileInfo.FullName;
        }
    }
}
