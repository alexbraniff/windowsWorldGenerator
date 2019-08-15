using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core
{
    public enum CameraType
    {
        [Description("None")]
        NONE = 0,
        [Description("Orthographic Camera")]
        Orthographic = 1,
        [Description("Perspective Camera")]
        Perspective = 2
    }
}
