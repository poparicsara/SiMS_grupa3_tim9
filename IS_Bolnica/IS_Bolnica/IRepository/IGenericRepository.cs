using System;
using System.Collections.Generic;

namespace IS_Bolnica.IRepository
{
    public interface IGenericRepository<T, M>
    {
        List<T> GetAll();
        T FindById(M id);
        void SaveToFile(List<T> entities);
        void Add(T newEntity);

        void Update(int index, T newEntity);
        void Delete(int index);
    }
}
