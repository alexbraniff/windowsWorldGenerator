using Engine.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Business.Infrastructure
{
    public interface IDto<T> where T : IEntity
    {
    }
}
