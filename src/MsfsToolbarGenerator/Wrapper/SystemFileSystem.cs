using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace De.Berndnet2000.MsfsToolbarGenerator.Wrapper {
    public class SystemFileSystem : IFileSystem {
        public IList<FileInfo> GetAllFilesInDirectory(DirectoryInfo directory) {
            return directory.GetFiles("*.*", SearchOption.AllDirectories);
        }

        public Task<string> ReadAllTextAsync(string file) {
            return File.ReadAllTextAsync(file);
        }

        public Task WriteAllTextAsync(string destinationFullPath, string fileContent) {
            return File.WriteAllTextAsync(destinationFullPath, fileContent);
        }
    }
}