using GrifindoPS.Services;
using GrifindoPS.Stores;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateEmpListViewModel();

            var window = new MainWindow
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            window.Show();

            base.OnStartup(e);
        }

        private EmployeeDetailsViewModel CreateEmpDetailsViewModel()
        {
            return new EmployeeDetailsViewModel(new NavigationService(_navigationStore, CreateEmpListViewModel));
        }

        private EmployeeListViewModel CreateEmpListViewModel()
        {
            return new EmployeeListViewModel(new NavigationService(_navigationStore, CreateEmpDetailsViewModel));
        }
    }
}
