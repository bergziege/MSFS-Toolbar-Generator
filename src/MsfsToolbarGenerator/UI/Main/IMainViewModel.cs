using System.Reactive;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main {
    public interface IMainViewModel {
        string WorkspaceFolder { get; }
        ReactiveCommand<Unit, Unit> SelectWorkspaceFolderCommand { get; }
    }
}