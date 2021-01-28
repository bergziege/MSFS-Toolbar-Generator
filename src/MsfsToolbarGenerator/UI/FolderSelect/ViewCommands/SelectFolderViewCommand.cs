using System.IO;
using System.Windows.Forms;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands {
    public class SelectFolderViewCommand : ISelectFolderViewCommand {
        public DirectoryInfo Execute() {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            return new DirectoryInfo(fbd.SelectedPath);
        }
    }
}