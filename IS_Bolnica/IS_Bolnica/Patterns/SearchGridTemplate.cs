using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Patterns
{
    public abstract class SearchGridTemplate<T>
    {
        public List<T> GetSearchedEntities(string text)
        {
            List<T> entities = GetAll();
            List<T> searchedEntities = new List<T>();
            foreach (var entity in entities)
            {
                if (ISearched(text, entity))
                {
                    searchedEntities.Add(entity);
                }
            }

            return searchedEntities;
        }

        public abstract bool ISearched(string text, T entity);

        public abstract List<T> GetAll();

    }
}
