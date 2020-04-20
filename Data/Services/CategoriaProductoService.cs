using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class CategoriaProductoService : ISingleModelSystemService<CategoriaProducto>
    {
        public CategoriaProducto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CategoriaProducto objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaProducto> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaProducto> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(CategoriaProducto objectType)
        {
            throw new NotImplementedException();
        }
    }
}
