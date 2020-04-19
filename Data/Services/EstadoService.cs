using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class EstadoService : ISingleModelSystemService<Estado>
    {
        public Estado FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var estado = context.Estados.Find(id);

                return estado;
            }
        }

        public void Insert(Estado objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateSingleObject(Estado objectType)
        {
            throw new NotImplementedException();
        }
    }
}
