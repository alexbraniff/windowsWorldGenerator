using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Engine.Core.Infrastructure.World
{
    public interface IProcedural
    {
        Vector3 Bounds { get; set; }
        IProcedural Generate();
        event EventHandler<EventArgs> Generated;
    }
}
