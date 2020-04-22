using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ImagenService : ISingleModelSystemService<ImagenProducto>
    {
        public ImagenProducto FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var imagenProducto = context.ImagenesProductos.Find(id);

                return imagenProducto;
            }
        }

        public void Insert(ImagenProducto imagenProducto)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.ImagenesProductos.Add(imagenProducto);

                context.SaveChanges();
            }
        }

        public IEnumerable<ImagenProducto> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var imagenesProductos = context.ImagenesProductos.ToList().Where(x => x.Borrado == false);

                return imagenesProductos;
            }
        }

        public IEnumerable<ImagenProducto> ListSortedByGivenCategoryId(int idProducto)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var imagenesProductosFromProducto = context.ImagenesProductos.ToList().Where(x => x.CodigoProducto == idProducto & x.Borrado == false);

                return imagenesProductosFromProducto;
            }
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void SoftDeleteByCodigoProducto(int idProducto)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var imagenesProductoFromProducto = context.ImagenesProductos.Where(x => x.CodigoProducto == idProducto & x.Borrado == false);

                if (imagenesProductoFromProducto.Count() > 0)
                {
                    foreach(var item in imagenesProductoFromProducto)
                    {
                        item.Borrado = true;
                    }
                }
            }
        }

        public void UpdateSingleObject(ImagenProducto objectType)
        {
            throw new NotImplementedException();
        }
    }
}
