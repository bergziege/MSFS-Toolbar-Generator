using System.IO;
using System.Reactive;
using System.Threading.Tasks;
using De.Berndnet2000.MsfsToolbarGenerator.Services;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands;
using ReactiveUI;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Main.ViewModels {
    public class MainViewModel : ReactiveObject, IMainViewModel {
        private readonly ILayoutCreationService _layoutCreationService;
        private readonly ISelectFolderViewCommand _selectFolderViewCommand;
        private readonly IToolbarCreationService _toolbarCreationService;
        private bool _isCreationInProgress;
        private ReactiveCommand<Unit, Unit> _packCommand;
        private ReactiveCommand<Unit, Unit> _selectTemplateFolderCommand;
        private ReactiveCommand<Unit, Unit> _selectWorkspaceFolderCommand;
        private ReactiveCommand<Unit, Unit> _startToolbarCreationCommand;
        private DirectoryInfo _templateFolder;
        private string _toolbarName;
        private DirectoryInfo _workspaceFolder;

        public MainViewModel(ISelectFolderViewCommand selectFolderViewCommand,
            IToolbarCreationService toolbarCreationService, ILayoutCreationService layoutCreationService) {
            _selectFolderViewCommand = selectFolderViewCommand;
            _toolbarCreationService = toolbarCreationService;
            _layoutCreationService = layoutCreationService;
        }

        public DirectoryInfo WorkspaceFolder
        {
            get => _workspaceFolder;
            private set => this.RaiseAndSetIfChanged(ref _workspaceFolder, value);
        }

        public DirectoryInfo TemplateFolder
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

        public bool IsCreationInProgress
        {
            get => _isCreationInProgress;
            private set => this.RaiseAndSetIfChanged(ref _isCreationInProgress, value);
        }

        public ReactiveCommand<Unit, Unit> StartToolbarCreationCommand
        {
            get { return _startToolbarCreationCommand ??= ReactiveCommand.CreateFromTask(OnStartCreateToolbarAsync); }
        }

        public string ToolbarName
        {
            get => _toolbarName;
            set => this.RaiseAndSetIfChanged(ref _toolbarName, value);
        }

        public ReactiveCommand<Unit, Unit> PackCommand
        {
            get { return _packCommand ??= ReactiveCommand.CreateFromTask(OnPackAsync); }
        }

        private async Task OnPackAsync() {
            IsCreationInProgress = true;
            await _layoutCreationService.CreateLayout(WorkspaceFolder);
            IsCreationInProgress = false;
        }

        private async Task OnStartCreateToolbarAsync() {
            IsCreationInProgress = true;
            await _toolbarCreationService.CreateToolbarAsync(TemplateFolder, WorkspaceFolder, ToolbarName);
            IsCreationInProgress = false;
        }
    }
}