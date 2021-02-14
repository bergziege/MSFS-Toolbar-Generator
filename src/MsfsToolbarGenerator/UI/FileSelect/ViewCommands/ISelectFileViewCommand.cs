using System.IO;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.FileSelect.ViewCommands
{
    public interface ISelectFileViewCommand
    {
        FileInfo Execute();
    }
}
