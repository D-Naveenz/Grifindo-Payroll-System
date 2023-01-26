using GrifindoPS.DBContexts;
using GrifindoPS.Services;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
using GrifindoPS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
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
        private readonly GrifindoContextFactory _dbContextFactory;

        public App()
        {
            InitConfig();

            // Loading config from file
            ConfigStore? _configs = ConfigStore.Load();

            _navigationStore = new();
            _dbContextFactory = new(_configs.ConnectionString);
            
            RuntimeStore.Initialize(_dbContextFactory, _configs);
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
            return EmployeeDetailsViewModel.LoadViewModel(
                new NavigationService(_navigationStore, CreateEmpListViewModel), 
                new NavigationService(_navigationStore, CreateLeavesListViewModel)
                );
        }
        
        private EmployeeListViewModel CreateEmpListViewModel()
        {
            return EmployeeListViewModel.LoadViewModel(
                new NavigationService(_navigationStore, CreateEmpDetailsViewModel),
                new NavigationService(_navigationStore, CreateSettingsViewModel),
                new NavigationService(_navigationStore, CreateEmpListViewModel)
                );
        }

        private LeavesListViewModel CreateLeavesListViewModel()
        {
            return LeavesListViewModel.LoadViewModel(
                new NavigationService(_navigationStore, CreateEmpDetailsViewModel), 
                new NavigationService(_navigationStore, CreateLeavesDetailsViewModel),
                new NavigationService(_navigationStore, CreateLeavesListViewModel)
                );
        }

        private LeavesDetailsViewModel CreateLeavesDetailsViewModel()
        {
            return new LeavesDetailsViewModel(new NavigationService(_navigationStore, CreateLeavesListViewModel));
        }

        private SettingsViewModel CreateSettingsViewModel()
        {
            return new SettingsViewModel(new NavigationService(_navigationStore, CreateEmpListViewModel));
        }

        private void InitConfig()
        {
            if (!File.Exists("config.json"))
            {
                // Create a new AppConfiguration object with default values
                ConfigStore configs = new(
                "Data Source=(local);Initial Catalog=GrifindoPS;Integrated Security=True;TrustServerCertificate=True;",
                new DateTime(2023, 1, 1),
                new DateTime(2023, 1, 31),
                210000
                );

                // Serialize the AppConfiguration object into a JSON string
                string json = JsonSerializer.Serialize(configs);

                // Create a new "config.json" file and write the JSON string to it
                File.WriteAllText("config.json", json);
            }

        }

        //private void MigrateDB()
        //{
        //    using (GrifindoContext dBContext = _dbContextFactory.CreateDbContext())
        //    {
        //        dBContext.Database.Migrate();
        //    }
        //}
    }
}
