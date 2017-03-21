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

        public bool IsDirectory { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public IDirectoryFileInfo Parent { get; set; }

        public long Length { get; set; }

        public string Extension { get; set; }

        public DateTime LastWriteTime { get; set; }


        public DirectoryFileInfo(DirectoryInfo directoryInfo)
        {
            Init(directoryInfo);
        }

        private void Init(DirectoryInfo directoryInfo)
        {
            IsFile = false;
            IsDirectory = true;
            Name = directoryInfo.Name;
            FullName = directoryInfo.FullName;
            if (directoryInfo.Parent != null)
            {
                Parent = new DirectoryFileInfo(directoryInfo.Parent);
            }

            LastWriteTime = directoryInfo.LastWriteTime;
            Extension = "DIR";
        }

        private void Init(FileInfo fileInfo)
        {
            IsFile = true;
            IsDirectory = false;
            Name = fileInfo.Name;
            FullName = fileInfo.FullName;
            if (fileInfo.Directory != null)
            {
                Parent = new DirectoryFileInfo(fileInfo.Directory);
            }

            Length = fileInfo.Length;
            Extension = fileInfo.Extension.ToLower();//.Replace(".","");
            LastWriteTime = fileInfo.LastWriteTime;
        }

        public DirectoryFileInfo(FileInfo fileInfo)
        {
            Init(fileInfo);
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
