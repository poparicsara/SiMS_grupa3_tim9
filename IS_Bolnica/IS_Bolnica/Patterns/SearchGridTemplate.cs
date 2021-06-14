using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Patterns
{
    public abstract class SearchGridTemplate<T>
    {
        private List<T> entities = new List<T>();

        public List<T> SearchedEntities(string text)
        {
            return GetSearchedEntities(text);
        }

        public abstract bool ISearched(string text, T entity);

        public abstract List<T> GetSearchedEntities(string text);

    }
}
