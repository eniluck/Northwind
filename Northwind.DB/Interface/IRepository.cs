using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DB.Interface
{
    public interface IRepository<Type,Key>
    {
        IEnumerable<Type> GetAll();
        Type Get(Key key);
        int Create(Type entity);
        int Update(Type entity);
        int Delete(Key key);
    }
}
