using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProvinciaService : ISingleModelSystemService<Provincia>
    {
        public Provincia FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var provincia = context.Provincias.Find(id);

                return provincia;
            }
        }

        public void Insert(Provincia objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provincia> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var provincias = context.Provincias.ToList();

                return provincias;
            }
        }

        public IEnumerable<Provincia> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateSingleObject(Provincia objectType)
        {
            throw new NotImplementedException();
        }
    }
}
