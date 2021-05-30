﻿using System;
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
            medicaments = GetAllMedicaments();
        }

        public void DeleteMedReplacement(Medicament selectedMedicament)
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

        public void SaveMedicament(Medicament medicament)
        {
            medicamentRepository.saveToFile(medicaments);
        }

        public void AddIngredientInMedicament(Ingredient ingredient, int medicamentId)
        {
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Id.Equals(medicamentId))
                {
                    medicament.Ingredients.Add(ingredient);
                    SaveMedicament(medicament);
                }
            }
        }

        public List<Medicament> ShowApprovedMedicaments()
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

        public Medicament SetMedicamentReplacement(string replacementName)
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

        public List<string> ShowMedicamentReplacements()
        {
            List<string> medicamentReplacements = new List<string>();
            foreach (Medicament medicament in medicaments)
            {
                medicamentReplacements.Add(medicament.Name);
            }
            return medicamentReplacements;
        }

        public int GetIndexOfOldMedicament(Medicament selectedMedicament)
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

        public void UpdateMedicament(Medicament updatedMedicament, int index)
        {
            medicaments.RemoveAt(index);
            medicaments.Insert(index, updatedMedicament);
            medicamentRepository.saveToFile(medicaments);
        }

        public List<Medicament> GetMedicaments()
        {
            return medicamentRepository.GetMedicaments();
        }

        public bool DoesChoosenMedContainsAllergens(string medName, string allergens)
        {
            for (int i = 0; i < medicaments.Count; i++)
            {
                if (medicaments[i].Name.Equals(medName))
                {
                    for (int j = 0; j < medicaments[i].Ingredients.Count; j++)
                    {
                        if (medicaments[i].Ingredients[j].Name.Equals(allergens))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void DeleteMedicament(int medicamentId)
        {
            int index = 0;
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Id.Equals(medicamentId))
                {
                    break;
                }

                index++;
            }
            medicaments.RemoveAt(index);
            medicamentRepository.saveToFile(medicaments);
        }

        public void ChangeMedicamentStatus(int medicamentId)
        {
            foreach (Medicament med in medicaments)
            {
                if (med.Id.Equals(medicamentId))
                {
                    med.Status = MedicamentStatus.approved;
                }
            }
            medicamentRepository.saveToFile(medicaments);
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

        private List<Medicament> GetAllMedicaments()
        {
            return medicamentRepository.GetMedicaments();
        }
    }
}
