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

      public List<Medicament> GetSearchedMeds(string text)
      {
          return repository.GetSearchedMeds(text);
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

      public void DeleteMedReplacement(Medicament selectedMedicament)
       {
            foreach (Medicament medicament in meds)
            {
                if (medicament.Id.Equals(selectedMedicament.Id))
                {
                    medicament.Replacement = new Medicament();
                }
            }
            medicamentRepository.saveToFile(meds);
        }

        public void SaveMedicament(Medicament medicament)
          {
              medicamentRepository.saveToFile(meds);
          }

          public void AddIngredientInMedicament(Ingredient ingredient, int medicamentId)
          {
              foreach (Medicament medicament in meds)
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
              foreach (Medicament medicament in meds)
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
              foreach (Medicament medicament in meds)
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
              foreach (Medicament medicament in meds)
              {
                  medicamentReplacements.Add(medicament.Name);
              }
              return medicamentReplacements;
          }

          public int GetIndexOfOldMedicament(Medicament selectedMedicament)
          {
              int index = 0;
              foreach (Medicament medicament in meds)
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
              meds.RemoveAt(index);
              meds.Insert(index, updatedMedicament);
              medicamentRepository.saveToFile(meds);
          }

          public bool DoesChoosenMedContainsAllergens(string medName, string allergens)
        {
            for (int i = 0; i < meds.Count; i++)
            {
                if (meds[i].Name.Equals(medName))
                {
                    for (int j = 0; j < meds[i].Ingredients.Count; j++)
                    {
                        if (meds[i].Ingredients[j].Name.Equals(allergens))
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
            foreach (Medicament medicament in meds)
            {
                if (medicament.Id.Equals(medicamentId))
                {
                    break;
                }

                index++;
            }
            meds.RemoveAt(index);
            medicamentRepository.saveToFile(meds);
        }

        public void ChangeMedicamentStatus(int medicamentId)
        {
            foreach (Medicament med in meds)
            {
                if (med.Id.Equals(medicamentId))
                {
                    med.Status = MedicamentStatus.approved;
                }
            }
            medicamentRepository.saveToFile(meds);
        }
        private List<Medicament> GetAllMedicaments()
        {
            return medicamentRepository.GetMedicaments();
        }
    }

 }
