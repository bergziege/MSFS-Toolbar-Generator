using System.Windows;
using De.Berndnet2000.MsfsToolbarGenerator.Services.Impl;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FileSelect.ViewCommands;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands;
using De.Berndnet2000.MsfsToolbarGenerator.UI.Main;
using De.Berndnet2000.MsfsToolbarGenerator.UI.Main.ViewModels;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;

namespace De.Berndnet2000.MsfsToolbarGenerator {
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            IFileSystem fileSystem = new SystemFileSystem();
            IMainViewModel vm = new MainViewModel(new SelectFolderViewCommand(),
                new ToolbarCreationService(fileSystem, new Tokenizer()), new LayoutCreationService(fileSystem),
                new BuildService(fileSystem), new SelectFileViewCommand());
            vm.LoadUserSettings();
            var view = new MainView();
            view.DataContext = vm;
            MainWindow = view;
            MainWindow.Show();
        }
    }
}
