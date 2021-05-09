using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Medicament Replacement { get; set; }
        public string Producer { get; set; }
        public MedicamentStatus Status { get; set; }
    }
}
