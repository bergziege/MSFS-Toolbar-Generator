using System.Reactive;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main.ViewModels {
    public class MainViewModel : ReactiveObject, IMainViewModel {
        private readonly ISelectFolderViewCommand _selectFolderViewCommand;
        private ReactiveCommand<Unit, Unit> _selectTemplateFolderCommand;
        private ReactiveCommand<Unit, Unit> _selectWorkspaceFolderCommand;
        private string _templateFolder;
        private string _workspaceFolder;

        public MainViewModel(ISelectFolderViewCommand selectFolderViewCommand) {
            _selectFolderViewCommand = selectFolderViewCommand;
        }

        public string WorkspaceFolder
        {
            get => _workspaceFolder;
            private set => this.RaiseAndSetIfChanged(ref _workspaceFolder, value);
        }

        public string TemplateFolder
        {
            get => _templateFolder;
            private set => this.RaiseAndSetIfChanged(ref _templateFolder, value);
        }

        public ReactiveCommand<Unit, Unit> SelectWorkspaceFolderCommand
        {
            get {
                return _selectWorkspaceFolderCommand ??= ReactiveCommand.Create(() =>
                {
                    WorkspaceFolder = _selectFolderViewCommand.Execute();
                });
            }
        }

        public ReactiveCommand<Unit, Unit> SelectTemplateFolderCommand
        {
            get {
                return _selectTemplateFolderCommand ??= ReactiveCommand.Create(() =>
                {
                    TemplateFolder = _selectFolderViewCommand.Execute();
                });
            }
        }
    }
}