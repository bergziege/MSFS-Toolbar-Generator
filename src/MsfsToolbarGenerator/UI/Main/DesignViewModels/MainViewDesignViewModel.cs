using System.Reactive;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main.DesignViewModels {
    public class MainViewDesignViewModel : IMainViewModel {
        public string WorkspaceFolder { get; } = "C:\\something";
        public string TemplateFolder { get; } = "D:\\template";
        public ReactiveCommand<Unit, Unit> SelectWorkspaceFolderCommand { get; } = ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit, Unit> SelectTemplateFolderCommand { get; } = ReactiveCommand.Create(() => { });
    }
}