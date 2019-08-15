using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Infrastructure.World
{
    public class CubeFace
    {
        public Vector3 CubeCenter { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 Up { get; set; }
        public double Distance { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool Visible { get; set; }
    }
}
