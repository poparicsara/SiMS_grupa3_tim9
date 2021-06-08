using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    class MedicamentService
    {
        private MedicamentRepository repository = new MedicamentRepository();
        private Medicament newMedicament = new Medicament();
        private List<Medicament> meds = new List<Medicament>();

        public MedicamentService()
        {
            meds = GetMedicaments();
        }

        public List<Medicament> GetMedicaments()
        {
            return repository.GetMedicaments();
        }

        public void AddMedicament(Medicament newMedicament, string ingredients)
        {
            this.newMedicament = newMedicament;
            this.newMedicament.Ingredients = GetIngredients(ingredients);
            repository.AddMedicament(newMedicament);
        }

        public List<string> GetReplacementNames()
        {
            List<string> replacemets = new List<string>();
            foreach (var m in meds)
            {
                replacemets.Add(m.Name);
            }
            return replacemets;
        }

        public Medicament GetMedicament(string name)
        {
            return repository.GetMedicament(name);
        }

        public void EditMedicament(Medicament oldMedicament, Medicament newMedicament)
        {
            int index = FindIndex(oldMedicament);
            repository.EditMedicament(index, newMedicament);
        }

        public bool IsMedNumberUnique(int medNumber)
        {
            return repository.IsMedNumberUnique(medNumber);
        }

        public bool HasMedicamentIngredient(Medicament medicament, String ingredient)
        {
            return repository.HasMedicamentIngredient(medicament, ingredient);
        }

        private int FindIndex(Medicament medicament)
        {
            meds = GetMedicaments();
            int index = 0;
            foreach (Medicament m in meds)
            {
                if (m.Id == medicament.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        private List<Ingredient> GetIngredients(string ingredients)
        {
            List<Ingredient> ings = new List<Ingredient>();
            string[] parts = ingredients.Split('\n');
            for (int i = 0; i < parts.Length; i++)
            {
                Ingredient ing = GetIngredient(parts, i);
                ings.Add(ing);
            }
            return ings;
        }

        private Ingredient GetIngredient(string[] ingredients, int index)
        {
            string temp = ingredients[index];
            if (ingredients[index].Contains('\r'))
            {
                int endIndex = ingredients[index].IndexOf('\r');
                temp = ingredients[index].Substring(0, endIndex);
            }
            Ingredient ingredient = new Ingredient { Name = temp };
            return ingredient;
        }

    }
}
