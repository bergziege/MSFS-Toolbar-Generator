using System.Windows;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands;
using De.Berndnet2000.MsfsToolbarGenerator.UI.Main;
using De.Berndnet2000.MsfsToolbarGenerator.UI.Main.ViewModels;
using MsfsToolbarGenerator.Services.Services.Impl;
using MsfsToolbarGenerator.Services.Wrapper;

namespace De.Berndnet2000.MsfsToolbarGenerator {
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            IMainViewModel vm = new MainViewModel(new SelectFolderViewCommand(), new ToolbarCreationService(new SystemFileSystem(), new Tokenizer()));
            MainView view = new MainView();
            view.DataContext = vm;
            MainWindow = view;
            MainWindow.Show();
        }
    }
}