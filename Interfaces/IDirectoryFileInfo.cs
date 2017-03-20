using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkExplorer.Interfaces
{
    public interface IDirectoryFileInfo
    {
        bool IsFile { get; set; }

        bool IsDirectory { get; set; }

        string Name { get; set; }

        string FullName { get; set; }

        IDirectoryFileInfo Parent { get; set; }
    }
}
