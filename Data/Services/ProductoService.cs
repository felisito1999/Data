using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoService : ISingleModelSystemService<Producto>
    {
        public Producto FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var producto = context.Productos.Find(id);

                return producto;
            }
        }

        public void Insert(Producto objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(Producto objectType)
        {
            throw new NotImplementedException();
        }
    }
}
