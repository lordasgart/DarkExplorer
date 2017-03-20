using DarkExplorer.Interfaces;
using DarkExplorer.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkExplorer
{
    public class ViewModel : BindableBase
    {
        ObservableCollection<IDirectoryFileInfo> _directoryFileInfos = new ObservableCollection<IDirectoryFileInfo>();

        public IDirectoryFileInfo SelectedDirectoryFileInfo { get; set; }

        public ViewModel()
        {
            string path = "C:\\";

            Show(path);
        }

        private void Show(string path)
        {
            _directoryFileInfos.Clear();

            var directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                DirectoryInfo di = new DirectoryInfo(dir);

                DirectoryFileInfos.Add(new DirectoryFileInfo(di));
            }

            var fileNames = Directory.GetFiles(path);
            foreach (var fileName in fileNames)
            {
                FileInfo fi = new FileInfo(fileName);

                DirectoryFileInfos.Add(new DirectoryFileInfo(fi));
            }
        }

        internal void Show()
        {
            if (SelectedDirectoryFileInfo.IsFile)
            {
                Process.Start(SelectedDirectoryFileInfo.FullName);
            }
            else
            {
                Show(SelectedDirectoryFileInfo.FullName);
            }
        }

        public ObservableCollection<IDirectoryFileInfo> DirectoryFileInfos { get => _directoryFileInfos; set => _directoryFileInfos = value; }
    }
}
