using System.IO;
using System.Threading.Tasks;

namespace De.Berndnet2000.MsfsToolbarGenerator.Services {
    public interface ILayoutCreationService {
        Task CreateLayout(DirectoryInfo workspace);
    }
}