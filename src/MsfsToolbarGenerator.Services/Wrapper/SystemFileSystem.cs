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

        public async Task CopyAsync(string source, string destination) {
            using (var sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
                FileOptions.Asynchronous | FileOptions.SequentialScan))
            using (var destinationStream = new FileStream(destination, FileMode.CreateNew, FileAccess.Write,
                FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan)) {
                await sourceStream.CopyToAsync(destinationStream);
            }
        }

        public void CheckDir(string directory) {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }
    }
}