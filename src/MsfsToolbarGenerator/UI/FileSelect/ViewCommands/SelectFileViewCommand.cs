using System.IO;
using System.Windows.Forms;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.FileSelect.ViewCommands
{
    public class SelectFileViewCommand : ISelectFileViewCommand
    {
        public FileInfo Execute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            return new FileInfo(openFileDialog.FileName);
        }
    }
}
