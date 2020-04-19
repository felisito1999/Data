using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class PaisService : ISingleModelSystemService<Pais>
    {
        public Pais FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var pais = context.Paises.Find(id);

                return pais;
            }
        }

        public void Insert(Pais objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var paises = context.Paises.ToList();

                return paises;
            }
        }

        public IEnumerable<Pais> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateSingleObject(Pais objectType)
        {
            throw new NotImplementedException();
        }
    }
}
