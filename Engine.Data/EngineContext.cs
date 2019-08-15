using Engine.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Data
{
    public class EngineContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }

        public EngineContext()
        {

        }
    }
}
