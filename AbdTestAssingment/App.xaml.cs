﻿using AdbTestAssingment.ViewModels;
using AdbTestAssingment.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdbTestAssingment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); 

            var viewModel = new MainWindowViewModel();
            var view = new MainWindow(viewModel);
            view.Show();
        }
    }
}
