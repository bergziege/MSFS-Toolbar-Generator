using System.IO;
using System.Threading.Tasks;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services {
    public class ToolbarCreationService : IToolbarCreationService {
        private readonly IFileSystem _fileSystem;

        public ToolbarCreationService(IFileSystem fileSystem) {
            _fileSystem = fileSystem;
        }

        public async Task CreateToolbarAsync(DirectoryInfo templateDirectory, DirectoryInfo workspaceDirectory) {
            var allTemplateFiles = _fileSystem.GetAllFilesInDirectory(templateDirectory);

            foreach (var templateFile in allTemplateFiles) {
                var relativePath = templateFile.FullName.Replace(templateDirectory.FullName, "");
                relativePath = ReplaceTokensWith(relativePath, "EBAG");
                var destinationFullPath = Path.Combine(workspaceDirectory.FullName, relativePath);

                if (templateFile.Extension.Contains("jpg")) {
                    templateFile.CopyTo(destinationFullPath);
                }
                else {
                    var fileContent = await _fileSystem.ReadAllTextAsync(templateFile.FullName);

                    fileContent = ReplaceTokensWith(fileContent, "EBAG");
                    DirectoryInfo? destination = new FileInfo(destinationFullPath).Directory;
                    if (!destination.Exists) {
                        destination.Create();
                    }
                    await _fileSystem.WriteAllTextAsync(destinationFullPath, fileContent);
                }
            }
        }

        private string ReplaceTokensWith(string value, string replacingValue) {
            value = value.Replace("#template#", replacingValue.ToLower());
            value = value.Replace("#Template#", replacingValue);
            value = value.Replace("#TEMPLATE#", replacingValue.ToUpper());
            return value;
        }
    }
}