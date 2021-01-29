using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MsfsToolbarGenerator.Services.Wrapper {
    public interface IFileSystem {
        IList<FileInfo> GetAllFilesInDirectory(DirectoryInfo directory);
        Task<string> ReadAllTextAsync(string file);
        Task WriteAllTextAsync(string destinationFullPath, string fileContent);
    }
}