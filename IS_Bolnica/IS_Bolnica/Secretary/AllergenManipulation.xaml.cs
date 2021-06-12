using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AllergenManipulation : Page
    {
        private Page previousPage;
        private string patientId;
        private IngredientService ingredientService = new IngredientService();
        private PatientService patientService = new PatientService();

        private Point startPoint = new Point();

        public ObservableCollection<Ingredient> IngredientsAll { get; set; }

        public ObservableCollection<Ingredient> IngredientsPatient { get; set; }

        public AllergenManipulation(Page previousPage, string patientId)
        {
            InitializeComponent();
            this.DataContext = this;
            this.previousPage = previousPage;
            this.patientId = patientId;
            if (patientService.PatientIdExists(this.patientId))
            {
                IngredientsAll = new ObservableCollection<Ingredient>(ingredientService.GetAllOtherIngredients(this.patientId));
                IngredientsPatient = new ObservableCollection<Ingredient>(ingredientService.GetPatientsIngredients(this.patientId));

            }
            else
            {
                IngredientsAll = new ObservableCollection<Ingredient>(ingredientService.GetAllIngredients());
                IngredientsPatient = new ObservableCollection<Ingredient>();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void EditAllergens(object sender, RoutedEventArgs e)
        {
            List<Ingredient> patientsAllergens = new List<Ingredient>(IngredientsPatient);
            patientService.SetPatientAllergens(patientsAllergens, patientId);
            IngredientsPatient = new ObservableCollection<Ingredient>();
            IngredientsAll = new ObservableCollection<Ingredient>();
            this.NavigationService.Navigate(previousPage);

        }

        private void CancelEditingAllergens(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);

        }

        private void AllAllergens_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void AllAllergens_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject) e.OriginalSource);

                if(listViewItem == null) return;

                Ingredient ingredient = (Ingredient)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                DataObject dragData = new DataObject("myFormat", ingredient);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T) current;
                }

                current = VisualTreeHelper.GetParent(current);
            } while (current != null);

            return null;
        }

        private void PatientsAllergens_OnDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void PatientsAllergens_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Ingredient ingredient = e.Data.GetData("myFormat") as Ingredient;
                IngredientsAll.Remove(ingredient);
                IngredientsPatient.Add(ingredient);
            }
        }

        private void AllAllergens_OnDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void AllAllergens_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Ingredient ingredient = e.Data.GetData("myFormat") as Ingredient;
                IngredientsPatient.Remove(ingredient);
                IngredientsAll.Add(ingredient);
            }
        }

        private void PatientsAllergens_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void PatientsAllergens_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null) return;

                Ingredient ingredient = (Ingredient)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                DataObject dragData = new DataObject("myFormat", ingredient);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }
    }
}
