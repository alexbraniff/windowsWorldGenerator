using Engine.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Business.Infrastructure
{
    public interface IBusinessObject<T, U> where T : IDto<U> where U : IEntity
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Save(T entity);
        T Add(T entity);
        T Delete(T entity);
    }
}
