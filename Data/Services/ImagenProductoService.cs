using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IEnumerable<ImagenProducto> ListSortedByGivenCategoryId(int idProducto)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var imagenes = context.ImagenesProductos.ToList().Where(x => x.CodigoProducto == idProducto & x.Borrado == false);

                return imagenes;
            }
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var imagen = context.ImagenesProductos.Find(id);
                imagen.Borrado = true;
            }
        }

        public void UpdateSingleObject(ImagenProducto objectType)
        {
            throw new NotImplementedException();
        }
        //public Image byteArrayToImage(byte[] imgBytes)
        //{
        //    using (MemoryStream imgStream = new MemoryStream(imgBytes))
        //    {
        //        return Image.FromStream(imgStream);
        //    }
        //}
    }
}
