using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IAcoustic
    {
        float GetAbsorptionCoefficient();
        float GetSpeedOfSoundCoefficient();
        float GetSoundReflectionCoefficient();
    }
}
