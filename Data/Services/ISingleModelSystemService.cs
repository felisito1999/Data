using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface ISingleModelSystemService<T> where T : class
    {
        void Insert(T objectType);
        IEnumerable<T> ListAll();
        IEnumerable<T> ListSortedByGivenCategoryId(int idCategory);
        T FindById(int id);
        void UpdateSingleObject(T objectType);
        void SoftDelete(int id);
    }
}
