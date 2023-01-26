﻿using GrifindoPS.DBContexts;
using GrifindoPS.Services;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
using GrifindoPS.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private readonly GrifindoContextFactory _dbContextFactory;
        private const string CONNECTIONSTR = "Data Source=(local);Initial Catalog=GrifindoPS;Integrated Security=True;TrustServerCertificate=True;";

        public App()
        {
            _navigationStore = new();
            _dbContextFactory = new(CONNECTIONSTR);
            ConfigStore.Initialize(_dbContextFactory);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateEmpListViewModel();

            //using (GrifindoContext dBContext = _dbContextFactory.CreateDbContext())
            //{
            //    dBContext.Database.Migrate();
            //}

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
                new NavigationService(_navigationStore, CreateEmpListViewModel)
                );
        }

        private LeavesListViewModel CreateLeavesListViewModel()
        {
            return new LeavesListViewModel(
                new NavigationService(_navigationStore, CreateEmpDetailsViewModel), 
                new NavigationService(_navigationStore, CreateLeavesDetailsViewModel),
                new NavigationService(_navigationStore, CreateLeavesListViewModel),
                _dbContextFactory
                );
        }

        private LeavesDetailsViewModel CreateLeavesDetailsViewModel()
        {
            return new LeavesDetailsViewModel(new NavigationService(_navigationStore, CreateLeavesListViewModel));
        }
    }
}
