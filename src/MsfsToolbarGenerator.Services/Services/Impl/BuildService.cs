using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services.Impl
{
    public class BuildService : IBuildService
    {
        private readonly IFileSystem _fileSystem;

        public BuildService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task CopyBuildArtifacts(DirectoryInfo workspaceFolder)
        {
            await CopyManifestToRoot(workspaceFolder);
            await CopySpbToInGamePanels(workspaceFolder);
        }

        public string GetPackageToolParameters(DirectoryInfo workspaceFolder)
        {
            return Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "*.xml").First();
        }

        public async Task PackAsync(FileInfo fsPackageTool, string fsPackageToolParameters,
            DirectoryInfo workspaceFolder)
        {
            Process.Start(fsPackageTool.FullName, fsPackageToolParameters);

            await WaitForBuildToFinish(workspaceFolder);
        }

        private async Task WaitForBuildToFinish(DirectoryInfo workspaceFolder)
        {
            while (!SpbAndManifestExists(workspaceFolder))
            {
                await Task.Delay(1000);
            }
        }

        private bool SpbAndManifestExists(DirectoryInfo workspaceFolder)
        {
            bool hasSpb = Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "*.spb",
                SearchOption.AllDirectories).FirstOrDefault() != null;
            bool hasManifest = Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "manifest.json",
                SearchOption.AllDirectories).FirstOrDefault() != null;

            return hasSpb && hasManifest;
        }

        private async Task CopySpbToInGamePanels(DirectoryInfo workspaceFolder)
        {
            string spbBuildArtifact =
                Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "*.spb",
                    SearchOption.AllDirectories).Single();
            string finalSpbFile =
                Path.Combine(workspaceFolder.FullName, "InGamePanels", Path.GetFileName(spbBuildArtifact));
            _fileSystem.CheckDir(Path.GetDirectoryName(finalSpbFile));
            await _fileSystem.CopyAsync(spbBuildArtifact, finalSpbFile);
        }

        private async Task CopyManifestToRoot(DirectoryInfo workspaceFolder)
        {
            string manifestFileName = "manifest.json";
            string manifestBuildArtifact =
                Directory.GetFiles(Path.Combine(workspaceFolder.FullName, "Build"), "manifest.json",
                    SearchOption.AllDirectories).Single();
            await _fileSystem.CopyAsync(manifestBuildArtifact,
                Path.Combine(workspaceFolder.FullName, manifestFileName));
        }
    }
}
