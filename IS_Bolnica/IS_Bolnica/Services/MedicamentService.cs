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
          return repository.GetAll();
      }

      public void AddMedicament(Medicament newMedicament, string ingredients)
      {
          this.newMedicament = newMedicament;
          this.newMedicament.Ingredients = GetIngredients(ingredients);
          repository.Add(newMedicament);
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

      public Medicament GetMedicamentByName(string name)
      {
          return repository.GetMedicamentByName(name);
      }

      public Medicament GetMedicamentById(int id)
      {
          return repository.FindById(id);
      }

      public void EditMedicament(Medicament oldMedicament, Medicament newMedicament)
      {
          int index = FindIndex(oldMedicament);
          repository.Update(index, newMedicament);
      }

      public bool IsMedNumberUnique(int medNumber)
      {
          foreach (var m in repository.GetAll())
          {
              if (m.Id == medNumber)
              {
                  return false;
              }
          }
          return true;
      }

      public bool HasMedicamentIngredient(Medicament medicament, String ingredient)
      {
          medicament = repository.FindById(medicament.Id);
          foreach (var i in medicament.Ingredients)
          {
              if (i.Name.Equals(ingredient))
              {
                  return true;
              }
          }

          return false;
      }

      public List<Medicament> GetSearchedMeds(string text)
      {
          List<Medicament> searchedmeds = new List<Medicament>();
          meds = GetMedicaments();
          foreach (var m in repository.GetAll())
          {
              if (IsSearched(text, m))
              {
                  searchedmeds.Add(m);
              }
          }
          return searchedmeds;
        }

      private static bool IsSearched(string text, Medicament m)
      {
          return m.Name.ToLower().StartsWith(text) || m.Producer.ToLower().StartsWith(text) || m.Status.ToString().StartsWith(text);
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

      public void UpdateMedicament(Medicament updatedMedicament, int index)
      {
          repository.Update(index, updatedMedicament);
      }


      public void DeleteMedicament(int medicamentId)
      {
          repository.Delete(medicamentId);
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

          repository.SaveToFile(meds);
      }

        private List<Medicament> GetAllMedicaments()
        {
            return repository.GetAll();
        }
    }

 }
