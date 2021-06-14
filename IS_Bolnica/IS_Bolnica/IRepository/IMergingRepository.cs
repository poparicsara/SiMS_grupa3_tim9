using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.IRepository
{
    interface IMergingRepository : IGenericRepository<Merging, int>
    {
        void EditMerging(int index);
    }
}
