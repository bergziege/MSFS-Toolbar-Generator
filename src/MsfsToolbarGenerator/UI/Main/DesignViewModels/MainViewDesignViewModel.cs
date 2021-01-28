using System.Reactive;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main.DesignViewModels {
    public class MainViewDesignViewModel : IMainViewModel {
        public string WorkspaceFolder { get; } = "C:\\something";
        public ReactiveCommand<Unit, Unit> SelectWorkspaceFolderCommand { get; } = ReactiveCommand.Create(() => { });
    }
}