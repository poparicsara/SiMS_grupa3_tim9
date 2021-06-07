using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AllergenManipulation : Page
    {
        private Page previousPage;
        private string id;
        private IngredientService ingredientService = new IngredientService();
        private PatientService patientService = new PatientService();

        public AllergenManipulation(Page previousPage, string patientsId)
        {
            InitializeComponent();
            this.DataContext = this;
            this.previousPage = previousPage;
            this.id = patientsId;
            if (patientService.PatientIdExists(this.id))
            {
                AllAllergens.ItemsSource = new ObservableCollection<Ingredient>(ingredientService.GetAllOtherIngredients(this.id));
                PatientsAllergens.ItemsSource = ingredientService.GetPatientsIngredients(this.id);

            }
            else
            {
                AllAllergens.ItemsSource = ingredientService.GetIngredients();
                PatientsAllergens.ItemsSource = new List<Ingredient>();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void EditAllergens(object sender, RoutedEventArgs e)
        {

        }

        private void CancelEditingAllergens(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
