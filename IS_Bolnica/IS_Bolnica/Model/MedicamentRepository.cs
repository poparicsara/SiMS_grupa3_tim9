﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Annotations;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private List<Medicament> meds;

        public MedicamentRepository()
        {
            meds = GetAll();
        }

        public void Add(Medicament newMedicament)
        {
            meds.Add(newMedicament);
            SaveToFile(meds);
        }

        public Medicament GetMedicament(string name)
        {
            Medicament medicament = new Medicament();
            foreach (var m in meds)
            {
                if (m.Name.Equals(name))
                {
                    medicament = m;
                }
            }
            return medicament;
        }

        public void Update(int index, Medicament newMedicament)
        {
            meds.RemoveAt(index);
            meds.Insert(index, newMedicament);
            SaveToFile(meds);
        }

        public void Delete(int id)
        {
            int index = 0;
            foreach (Medicament medicament in meds)
            {
                if (medicament.Id.Equals(id))
                {
                    break;
                }

                index++;
            }
            meds.RemoveAt(index);
            SaveToFile(meds);
        }

        public List<Medicament> GetAll()
        {
            var medicaments = new List<Medicament>();

            using (StreamReader file = File.OpenText("Lekovi.json"))
            {
                var serializer = new JsonSerializer();
                medicaments = (List<Medicament>)serializer.Deserialize(file, typeof(List<Medicament>));
            }

            return medicaments;
        }

        public List<Ingredient> GetIngredients(Medicament medicament)
        {
            medicament = GetMedicament(medicament.Name);
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var i in medicament.Ingredients)
            {
                ingredients.Add(i);
            }
            return ingredients;
        }

        public List<Ingredient> GetIngredients()
        {
            throw new NotImplementedException();
        }

        public void AddIngredient(Medicament medicament, Ingredient ingredient)
        {
            medicament = GetMedicament(medicament.Name);
            CheckMedicamentIngredients(medicament);
            medicament.Ingredients.Add(ingredient);
            SaveToFile(meds);
        }

        public Medicament GetMedicamentByName(string name)
        {
            throw new NotImplementedException();
        }

        public void CheckMedicamentIngredients(Medicament medicament)
        {
            if (medicament.Ingredients == null)
            {
                medicament.Ingredients = new List<Ingredient>();
            }
        }

        public void DeleteIngredient(Medicament medicament, int index)
        {
            medicament = GetMedicament(medicament.Name);
            medicament.Ingredients.RemoveAt(index);
            SaveToFile(meds);
        }

        public void EditIngredient(Medicament medicament, Ingredient ingredient, int index)
        {
            throw new NotImplementedException();
        }

        public void EditIngredient(Medicament medicament, int index, Ingredient newIngredient)
        {
            medicament = GetMedicament(medicament.Name);
            medicament.Ingredients.RemoveAt(index);
            medicament.Ingredients.Insert(index, newIngredient);
            SaveToFile(meds);
        }

        public bool HasMedicamentIngredient(Medicament medicament, String ingredient)
        {
            medicament = GetMedicament(medicament.Name);
            foreach (var i in medicament.Ingredients)
            {
                if (i.Name.Equals(ingredient))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMedNumberUnique(int medNumber)
        {
            foreach (Medicament m in meds)
            {
                if (m.Id == medNumber)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Medicament> GetSearchedMeds(string text)
        {
            List<Medicament> searchedmeds = new List<Medicament>();
            meds = GetAll();
            foreach (var m in meds)
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

        public void SaveToFile(List<Medicament> medicaments)
        {
            string jsonString = JsonConvert.SerializeObject(medicaments, Formatting.Indented);
            File.WriteAllText("Lekovi.json", jsonString);
        }

    }
}
