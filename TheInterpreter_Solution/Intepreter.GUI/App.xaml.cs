using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Intepreter.GUI.View;
using Intepreter.GUI.ViewModel;

namespace Intepreter.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mainWindow = new MainWindowView
            {
                DataContext = new MainViewModel()
            };

            mainWindow.Show();
        }
    }
}
