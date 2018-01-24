using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFCore.ServiceLocator;
using WPFCoreSample.Services;
using WPFCoreSample.Windows;

namespace WPFCoreSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterServices();
            new MainWindow().Show();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register<ILogger, Logger>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
