using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Intepreter.View;
using Intepreter.ViewModel;
using Intepreter.Service;

namespace Intepreter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mainWindow = new MainWindowView();

            mainWindow.Show();
        }
    }
}
