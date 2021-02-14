using System;
using System.Windows;
using De.Berndnet2000.MsfsToolbarGenerator.Services;
using De.Berndnet2000.MsfsToolbarGenerator.Services.Impl;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FileSelect.ViewCommands;
using De.Berndnet2000.MsfsToolbarGenerator.UI.FolderSelect.ViewCommands;
using De.Berndnet2000.MsfsToolbarGenerator.UI.Main;
using De.Berndnet2000.MsfsToolbarGenerator.UI.Main.ViewModels;
using De.Berndnet2000.MsfsToolbarGenerator.Wrapper;
using Microsoft.Extensions.DependencyInjection;

namespace De.Berndnet2000.MsfsToolbarGenerator
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISelectFileViewCommand, SelectFileViewCommand>();
            serviceCollection.AddSingleton<ISelectFolderViewCommand, SelectFolderViewCommand>();

            serviceCollection.AddSingleton<IMainViewModel, MainViewModel>();

            serviceCollection.AddSingleton<IFileSystem, SystemFileSystem>();

            serviceCollection.AddSingleton<IBuildService, BuildService>();
            serviceCollection.AddSingleton<ILayoutCreationService, LayoutCreationService>();
            serviceCollection.AddSingleton<ITokenizer, Tokenizer>();
            serviceCollection.AddSingleton<IToolbarCreationService, ToolbarCreationService>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IMainViewModel vm = _serviceProvider.GetService<IMainViewModel>();
            vm.LoadUserSettings();
            var view = new MainView();
            view.DataContext = vm;
            MainWindow = view;
            MainWindow.Show();
        }
    }
}
