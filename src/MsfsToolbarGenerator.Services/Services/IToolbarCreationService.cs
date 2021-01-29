using System.IO;
using System.Threading.Tasks;

namespace MsfsToolbarGenerator.Services.Services {
    public interface IToolbarCreationService {
        Task CreateToolbarAsync(DirectoryInfo templateDirectory, DirectoryInfo workspaceDirectory);
    }
}