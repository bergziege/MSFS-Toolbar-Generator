using System.IO;
using System.Reactive;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main.DesignViewModels
{
    public class MainViewDesignViewModel : IMainViewModel
    {
        public DirectoryInfo WorkspaceFolder { get; } = new DirectoryInfo("C:\\something");
        public DirectoryInfo TemplateFolder { get; } = new DirectoryInfo("D:\\template");
        public ReactiveCommand<Unit, Unit> SelectWorkspaceFolderCommand { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit, Unit> SelectTemplateFolderCommand { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit, Unit> SelectFsPackageToolCommand { get; } = ReactiveCommand.Create(() => { });
        public string FsPackageToolParameters { get; set; } = "toolbar.xml";
        public bool IsCreationInProgress { get; } = true;
        public ReactiveCommand<Unit, Unit> StartToolbarCreationCommand { get; } = ReactiveCommand.Create(() => { });
        public string ToolbarName { get; set; } = "ToolbarName";
        public ReactiveCommand<Unit, Unit> PackCommand { get; } = ReactiveCommand.Create(() => { });
        public FileInfo FsPackageTool { get; } = new FileInfo("fspackagetool.exe");
        public void LoadUserSettings() => throw new System.NotImplementedException();
    }
}
