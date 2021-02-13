using System.IO;
using System.Linq;
using System.Threading.Tasks;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services.Impl {
    public class BuildService : IBuildService {
        private readonly IFileSystem _fileSystem;

        public BuildService(IFileSystem fileSystem) {
            _fileSystem = fileSystem;
        }

        public async Task CopyBuildArtifacts(DirectoryInfo workspaceFolder) {
            await CopyManifestToRoot(workspaceFolder);
            await CopySpbToInGamePanels(workspaceFolder);
        }

        private async Task CopySpbToInGamePanels(DirectoryInfo workspaceFolder) {
            string spbBuildArtifact =
                Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "*.spb", SearchOption.AllDirectories).Single();
            string finalSpbFile = Path.Combine(workspaceFolder.FullName, "InGamePanels", Path.GetFileName(spbBuildArtifact));
            _fileSystem.CheckDir(Path.GetDirectoryName(finalSpbFile));
            await _fileSystem.CopyAsync(spbBuildArtifact, finalSpbFile);
        }

        private async Task CopyManifestToRoot(DirectoryInfo workspaceFolder) {
            string manifestFileName = "manifest.json";
            string manifestBuildArtifact =
                Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "manifest.json", SearchOption.AllDirectories).Single();
            await _fileSystem.CopyAsync(manifestBuildArtifact, Path.Combine(workspaceFolder.FullName, manifestFileName));
        }
    }
}