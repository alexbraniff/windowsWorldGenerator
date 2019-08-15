using Engine.Business.Entity;
using Engine.Core.Infrastructure.Engine;
using Engine.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core
{
    public class CoreModule : IModule
    {
        private IKernel kernel;

        public CoreModule()
        {
            kernel = Setup.GetKernel();
            Material material = kernel.Get<Material>();
            material.Add(new Business.Dto.MaterialDto
            {
                Id = 1
            });
        }
    }
}
