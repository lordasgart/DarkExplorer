using DarkExplorer.Interfaces;
using DarkExplorer.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DarkExplorer
{
    public class ViewModel : BindableBase
    {
        private string _currentPath;
        public string CurrentPath
        {
            get { return _currentPath; }
            set { SetProperty(ref _currentPath, value); }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set { SetProperty(ref _error, value); }
        }


        ObservableCollection<IDirectoryFileInfo> _directoryFileInfos = new ObservableCollection<IDirectoryFileInfo>();

        public IDirectoryFileInfo SelectedDirectoryFileInfo { get; set; }

        private ObservableCollection<IDirectoryFileInfo> _favorites = new ObservableCollection<IDirectoryFileInfo>();
        public ObservableCollection<IDirectoryFileInfo> Favorites
        {
            get { return _favorites; }
            set { SetProperty(ref _favorites, value); }
        }

        public IDirectoryFileInfo SelectedFavorite { get; set; }

        public ViewModel()
        {
            string path = "C:\\";

            Show(path);


            AddFavorite(@"C:\");
            AddFavorite(@"C:\Users\malzma\OneDrive");
            AddFavorite(@"C:\Users\malzma\Projects");
            AddFavorite(@"C:\_svn\shelves");        
            AddFavorite(@"C:\ProgramData\IT2media\SalesNetwork");                        
        }

        void AddFavorite(string path)
        {
            if (Directory.Exists(path))
            Favorites.Add(new DirectoryFileInfo(path));
        }

        private void Show(string path)
        {
            try
            {
                CurrentPath = path;
                Error = string.Empty;

                _directoryFileInfos.Clear();

                var directories = Directory.GetDirectories(path);
                foreach (var dir in directories.OrderBy((s => s)))
                {
                    DirectoryInfo di = new DirectoryInfo(dir);

                    DirectoryFileInfos.Add(new DirectoryFileInfo(di));
                }

                var fileNames = Directory.GetFiles(path);
                foreach (var fileName in fileNames.OrderBy((s => s)))
                {
                    FileInfo fi = new FileInfo(fileName);

                    DirectoryFileInfos.Add(new DirectoryFileInfo(fi));
                }
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
            }
        }

        internal void ShowFavorite()
        {
            Show(SelectedFavorite.FullName);
        }

        internal void Up()
        {
            DirectoryFileInfo dfi = new DirectoryFileInfo(CurrentPath);
            if (dfi.Parent != null)
            Show(dfi.Parent.FullName);
        }

        internal void ShowPath()
        {
            Show(CurrentPath);
        }

        internal void Back()
        {
            //throw new NotImplementedException();
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
