using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class Allergen
    {
        public string Name { get; set; }
        public List<Ingredient> IngredientsAllergens { get; set; }
        public List<Medicament> MedicamentsAllergens { get; set; }
    }
}
