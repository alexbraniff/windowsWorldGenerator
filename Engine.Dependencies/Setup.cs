using Engine.Business.Entity;
using Engine.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Dependencies
{
    public static class Setup
    {
        private static readonly IKernel container = new StandardKernel();
        private static bool configured = false;

        public static IKernel GetKernel()
        {
            if (!configured)
                ConfigureContainer();
            return container;
        }

        private static void ConfigureContainer()
        {
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Configuring Container... Should only happen once...");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            container.Bind<EngineContext>().To<EngineContext>().InSingletonScope();
            container.Bind<Material>().To<Material>().InSingletonScope();

            configured = true;
        }
    }
}
