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
            using (var context = GetService.GetRestauranteEntityService())
            {
                var categoria = context.CategoriasProductos.Find(id);

                return categoria;
            }
        }

        public void Insert(CategoriaProducto objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaProducto> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var categoriasProductos = context.CategoriasProductos.ToList();

                return categoriasProductos;
            }
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
