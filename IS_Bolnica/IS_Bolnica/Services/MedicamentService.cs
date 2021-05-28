using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    public class MedicamentService
    {
        private MedicamentRepository medicamentRepository = new MedicamentRepository();
        private List<Medicament> medicaments = new List<Medicament>();
        public MedicamentService()
        {
            medicaments = getMedicaments();
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
            medicamentRepository.saveToFile(medicaments, "Lekovi.json");
        }

        public void saveMedicament(Medicament medicament)
        {
            medicamentRepository.saveToFile(medicaments, "Lekovi.json");
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
            medicamentRepository.saveToFile(medicaments, "Lekovi.json");
        }

        private List<Medicament> getMedicaments()
        {
            return medicamentRepository.loadFromFile("Lekovi.json");
        }
    }
}
