using Engine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Business
{
    public abstract class BusinessObject
    {
        protected EngineContext Context { get; set; }

        public BusinessObject(EngineContext context)
        {
            Context = context;
        }
    }
}
