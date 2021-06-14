using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.Director.Commands;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Director.ViewModel
{
    public class AddIngredientViewModel
    {
        public string Name { get; set; }
        private Medicament medicament;
        private RelayCommand saveCommand;
        private IngredientService ingredientService = new IngredientService();

        public AddIngredientViewModel(Medicament selectedMedicament)
        {
            medicament = selectedMedicament;
            saveCommand = new RelayCommand(Save);
        }

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private void Save()
        {
            Ingredient newIngredient = new Ingredient {Name = this.Name};
            ingredientService.AddIngredient(medicament, newIngredient);
        }

    }
}
