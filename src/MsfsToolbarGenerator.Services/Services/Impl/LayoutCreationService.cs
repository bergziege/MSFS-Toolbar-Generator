using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using De.Berndnet2000.MsfsToolbarGenerator.LayoutJson;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;
using File = De.Berndnet2000.MsfsToolbarGenerator.LayoutJson.File;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services.Impl {
    public class LayoutCreationService : ILayoutCreationService {
        private readonly IFileSystem _fileSystem;

        public LayoutCreationService(IFileSystem fileSystem) {
            _fileSystem = fileSystem;
        }

        public async Task CreateLayout(DirectoryInfo workspace) {
            var layout = new Layout();
            var basePath = workspace.FullName;
            if (!basePath.EndsWith(Path.DirectorySeparatorChar)) basePath += Path.DirectorySeparatorChar;

            foreach (var file in workspace.GetFiles("*.*", SearchOption.AllDirectories)) {
                var relativePath = file.FullName.Replace(basePath, "");

                if (relativePath.StartsWith("Build") || relativePath.StartsWith("manifest.json")) continue;

                var content = new File
                {
                    Path = relativePath,
                    Size = file.Length,
                    Date = file.LastWriteTimeUtc.ToFileTimeUtc()
                };

                layout.Content.Add(content);
            }

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            var json = JsonSerializer.Serialize(layout, jsonOptions);

            await _fileSystem.WriteAllTextAsync(Path.Combine(workspace.FullName, "layout.json"),
                json.Replace("\r\n", "\n"));
        }
    }
}