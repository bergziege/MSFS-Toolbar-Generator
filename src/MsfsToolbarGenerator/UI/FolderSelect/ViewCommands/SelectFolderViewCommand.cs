using System.Windows.Forms;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands {
    public class SelectFolderViewCommand : ISelectFolderViewCommand {
        public string Execute() {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }
    }
}