using System.IO;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands {
    public interface ISelectFolderViewCommand {
        DirectoryInfo Execute();
    }
}