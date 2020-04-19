using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ImagenProductoService : ISingleModelSystemService<ImagenProducto>
    {
        public ImagenProducto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ImagenProducto imagen)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.ImagenesProductos.Add(imagen);

                context.SaveChanges();
            }
        }

        public IEnumerable<ImagenProducto> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImagenProducto> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(ImagenProducto objectType)
        {
            throw new NotImplementedException();
        }
    }
}
