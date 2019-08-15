using Engine.Core.Infrastructure.World.MaterialProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.World.MaterialProperties
{
    public class Acoustic : IAcoustic
    {
        public float GetAbsorptionCoefficient()
        {
            throw new NotImplementedException();
        }

        public float GetSoundReflectionCoefficient()
        {
            throw new NotImplementedException();
        }

        public float GetSpeedOfSoundCoefficient()
        {
            throw new NotImplementedException();
        }
    }
}
