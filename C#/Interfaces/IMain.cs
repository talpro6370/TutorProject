using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor_Database.Interfaces
{
    public interface IMain<T> where T : IPoco
    {
        T GetById(long id);
        List<T> GetAll();
        bool Add(T t);
        void Remove(T t);
        void Update(T t);
    }
}
