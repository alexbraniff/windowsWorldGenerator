using Engine.Core.Infrastructure.World.MaterialProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.World.MaterialProperties
{
    public class Radiological : IRadiological
    {
        public float GetNeutronCrossSection()
        {
            throw new NotImplementedException();
        }

        public float GetSpecificActivity()
        {
            throw new NotImplementedException();
        }
    }
}
