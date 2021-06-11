using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Annotations;

namespace IS_Bolnica.IRepository
{
    public interface IGenericRepository<T, M>
    {
        List<T> GetAll();
        T FindById(M id);
        void SaveToFile(List<T> entities);
        void Update(T oldEntity, T newEntity);
        void Delete(M id);
    }
}
