using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Engine.Data;
using GraphicsTest;
using Ninject;

namespace Game.Windows
{

    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            container = new StandardKernel();
            container.Bind<MainWindow>().To<MainWindow>().InSingletonScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = container.Get<MainWindow>();
            Current.MainWindow.Title = "DI with Ninject";
        }
    }
}
