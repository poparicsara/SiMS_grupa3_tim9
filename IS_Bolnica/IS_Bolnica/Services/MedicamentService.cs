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
        private MedicamentRepository medicamentRepository = new MedicamentRepository();
        private Medicament newMedicament = new Medicament();
        private List<Medicament> medicaments = new List<Medicament>();

        public MedicamentService()
        {
            medicaments = getMedicaments();
        }

        public List<Medicament> GetMedicaments()
        {
            return medicamentRepository.GetMedicaments();
        }

        public void AddMedicament(Medicament newMedicament, string ingredients)
        {
            this.newMedicament = newMedicament;
            this.newMedicament.Ingredients = GetIngredients(ingredients);
            medicamentRepository.AddMedicament(newMedicament);
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

        public void deleteMedReplacement(Medicament selectedMedicament)
        {
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Id.Equals(selectedMedicament.Id))
                {
                    medicament.Replacement = null;
                }
            }
            medicamentRepository.saveToFile(medicaments);
        }

        public void saveMedicament(Medicament medicament)
        {
            medicamentRepository.saveToFile(medicaments);
        }

        public void addIngredientInMedicament(Ingredient ingredient, int medicamentId)
        {
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Id.Equals(medicamentId))
                {
                    medicament.Ingredients.Add(ingredient);
                    saveMedicament(medicament);
                }
            }
        }

        public List<Medicament> showApprovedMedicaments()
        {
            List<Medicament> approvedMedicaments = new List<Medicament>();
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Status == MedicamentStatus.approved)
                {
                    approvedMedicaments.Add(medicament);
                }
            }
            return approvedMedicaments;
        }

        public Medicament setMedicamentReplacement(string replacementName)
        {
            Medicament replacement = new Medicament();
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Name.Equals(replacementName))
                {
                    replacement = medicament;
                }
            }
            return replacement;
        }

        public List<string> showMedicamentReplacements()
        {
            List<string> medicamentReplacements = new List<string>();
            foreach (Medicament medicament in medicaments)
            {
                medicamentReplacements.Add(medicament.Name);
            }
            return medicamentReplacements;
        }

        public int getIndexOfOldMedicament(Medicament selectedMedicament)
        {
            int index = 0;
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Id.Equals(selectedMedicament.Id))
                {
                    break;
                }

                index++;
            }

            return index;
        }

        public void updateMedicament(Medicament updatedMedicament, int index)
        {
            medicaments.RemoveAt(index);
            medicaments.Insert(index, updatedMedicament);
            medicamentRepository.saveToFile(medicaments);
        }

        private List<Medicament> getMedicaments()
        {
            return medicamentRepository.GetMedicaments();
        }
    }
}
