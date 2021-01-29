using System.IO;
using System.Threading.Tasks;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services {
    public interface IToolbarCreationService {
        Task CreateToolbarAsync(DirectoryInfo templateDirectory, DirectoryInfo workspaceDirectory, string toolbarName);
    }
}