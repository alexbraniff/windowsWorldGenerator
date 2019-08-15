using Engine.Core.Infrastructure.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Generation.Noise
{
    public class TestNoise : INoise
    {
        public float GetNoise(float x, float y, float z)
        {
            return 0;
        }
    }
}
