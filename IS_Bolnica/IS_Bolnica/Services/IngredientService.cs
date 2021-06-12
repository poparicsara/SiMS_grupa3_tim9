using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public partial class IngredientService
    {
        private IngredientRepository ingredientRepository = new IngredientRepository();
        private PatientService patientService = new PatientService();
        private MedicamentRepository repository = new MedicamentRepository();

        public IngredientService()
        {

        }

        public List<Ingredient> GetIngredients(Medicament medicament)
        {
            return repository.GetIngredients(medicament);
        }

        public void AddIngredient(Medicament medicament, Ingredient ingredient)
        {
            repository.AddIngredient(medicament, ingredient);
        }

        public void DeleteIngredient(Medicament medicament, Ingredient ingredient)
        {
            int index = GetIndex(medicament, ingredient);
            repository.DeleteIngredient(medicament, index);
        }

        public void EditIngredient(Medicament medicament, Ingredient oldIngredient, Ingredient newIngredient)
        {
            int index = GetIndex(medicament, oldIngredient);
            repository.EditIngredient(medicament, index, newIngredient);
        }

        private int GetIndex(Medicament medicament, Ingredient ingredient)
        {
            int index = 0;
            foreach (var i in medicament.Ingredients)
            {
                if (i.Name.Equals(ingredient.Name))
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public List<Ingredient> GetIngredients()
        {
            return ingredientRepository.GetAll();
        }

        public List<Ingredient> GetPatientsIngredients(string id)
        {
            Patient patient = patientService.FindById(id);
            if (patient.Ingredients != null)
            {
                return patient.Ingredients;
            }
            else
            {
                return new List<Ingredient>();
            }
        }

        public List<Ingredient> GetAllOtherIngredients(string id)
        {
            List<Ingredient> ingredients = ingredientRepository.GetAll();
            List<Ingredient> allOtheriIngredients = new List<Ingredient>();
            List<Ingredient> patientIngredients = GetPatientsIngredients(id);
            if (patientIngredients.Count == 0)
            {
                return ingredients;
            }

            int brojac = 0;

            foreach (var ingredient in ingredients)
            {
                brojac = 0;
                foreach (var patientIngredient in patientIngredients)
                {
                    if (ingredient.Name.Equals(patientIngredient.Name))
                    {
                        brojac++;
                    }
                }

                if (brojac == 0)
                {
                    allOtheriIngredients.Add(ingredient);
                }
            }

            return allOtheriIngredients;
        }
    }
}
