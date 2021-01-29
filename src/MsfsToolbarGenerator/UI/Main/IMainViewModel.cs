using System.IO;
using System.Reactive;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main {
    public interface IMainViewModel {
        DirectoryInfo WorkspaceFolder { get; }
        DirectoryInfo TemplateFolder { get; }
        ReactiveCommand<Unit, Unit> SelectWorkspaceFolderCommand { get; }
        ReactiveCommand<Unit, Unit> SelectTemplateFolderCommand { get; }
        bool IsCreationInProgress { get; }
        ReactiveCommand<Unit, Unit> StartToolbarCreationCommand { get; }
        string ToolbarName { get; set; }
    }
}