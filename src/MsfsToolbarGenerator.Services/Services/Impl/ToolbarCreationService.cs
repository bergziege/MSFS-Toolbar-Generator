using System.IO;
using System.Threading.Tasks;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services.Impl {
    public class ToolbarCreationService : IToolbarCreationService {
        private readonly IFileSystem _fileSystem;
        private readonly ITokenizer _tokenizer;

        public ToolbarCreationService(IFileSystem fileSystem, ITokenizer tokenizer) {
            _fileSystem = fileSystem;
            _tokenizer = tokenizer;
        }

        public async Task CreateToolbarAsync(DirectoryInfo templateDirectory, DirectoryInfo workspaceDirectory,
            string toolbarName) {
            var allTemplateFiles = _fileSystem.GetAllFilesInDirectory(templateDirectory);

            foreach (var templateFile in allTemplateFiles) {
                var relativePath = templateFile.FullName.Replace(templateDirectory.FullName, "");
                relativePath = _tokenizer.Replace(relativePath, toolbarName);
                if (relativePath.StartsWith(Path.DirectorySeparatorChar))
                    relativePath = relativePath.Substring(1, relativePath.Length - 1);
                var destinationFullPath = Path.Combine(workspaceDirectory.FullName, relativePath);

                if (templateFile.Extension.Contains("jpg")) {
                    templateFile.CopyTo(destinationFullPath);
                }
                else {
                    var fileContent = await _fileSystem.ReadAllTextAsync(templateFile.FullName);

                    fileContent = _tokenizer.Replace(fileContent, toolbarName);
                    var destination = new FileInfo(destinationFullPath).Directory;
                    if (!destination.Exists) destination.Create();
                    await _fileSystem.WriteAllTextAsync(destinationFullPath, fileContent);
                }
            }
        }
    }
}