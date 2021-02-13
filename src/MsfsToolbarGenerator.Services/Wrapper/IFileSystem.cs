using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace De.Berndnet2000.MsfsToolbarGenerator.Wrapper {
    public interface IFileSystem {
        IList<FileInfo> GetAllFilesInDirectory(DirectoryInfo directory);
        Task<string> ReadAllTextAsync(string file);
        Task WriteAllTextAsync(string destinationFullPath, string fileContent);
        Task CopyAsync(string source, string destination);
        void CheckDir(string directory);
    }
}