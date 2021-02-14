using System.IO;
using System.Threading.Tasks;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services
{
    public interface IBuildService
    {
        Task CopyBuildArtifacts(DirectoryInfo workspaceFolder);
        string GetPackageToolParameters(DirectoryInfo workspaceFolder);
        Task PackAsync(FileInfo fsPackageTool, string fsPackageToolParameters, DirectoryInfo workspaceFolder);
    }
}
