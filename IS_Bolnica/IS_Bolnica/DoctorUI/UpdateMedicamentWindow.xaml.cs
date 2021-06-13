using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class UpdateMedicamentWindow : Window
    {
        private UserService userService = new UserService();
        private Medicament selectedMedication;
        private Medicament updatedMedicament = new Medicament();
        private MedicamentService medicamentService = new MedicamentService();
        private IngredientService ingredientService = new IngredientService();
        private Point startPoint = new Point();
        public ObservableCollection<Ingredient> MedIngredients { get; set; }
        public ObservableCollection<Ingredient> AllIngredients { get; set; }
        public UpdateMedicamentWindow(Medicament medicament)
        {
            InitializeComponent();
            this.DataContext = this;
            this.selectedMedication = medicament;
            idTxt.Text = selectedMedication.Id.ToString();
            nameTxt.Text = selectedMedication.Name;
            producerTxt.Text = selectedMedication.Producer;

            if (selectedMedication.Replacement != null)
            {
                replacementsCB.SelectedItem = selectedMedication.Replacement.Name;
            }

            replacementsCB.ItemsSource = medicamentService.ShowMedicamentReplacements();

            AllIngredients = new ObservableCollection<Ingredient>(ingredientService.GetIngredients());
            MedIngredients = new ObservableCollection<Ingredient>(selectedMedication.Ingredients);

            confirmBTN.IsEnabled = false;
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            updatedMedicament.Id = (int)Int64.Parse(idTxt.Text);
            updatedMedicament.Name = nameTxt.Text;
            updatedMedicament.Producer = producerTxt.Text;
            updatedMedicament.Replacement = medicamentService.SetMedicamentReplacement(replacementsCB.SelectedItem.ToString());
            updatedMedicament.Ingredients = new List<Ingredient>(MedIngredients);

            int index = medicamentService.FindIndex(selectedMedication);
            medicamentService.UpdateMedicament(updatedMedicament, index);

            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }


        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Izmena leka", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
                    medicamentsWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjavljivanje", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    userService.LogOut();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void AllIngredients_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void AllIngredients_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance
                 || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject) e.OriginalSource);

                if (listViewItem == null) return;

                Ingredient ingredient = (Ingredient) listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

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
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void MedIngredients_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MedIngredients_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Ingredient ingredient = e.Data.GetData("myFormat") as Ingredient;
                AllIngredients.Remove(ingredient);
                MedIngredients.Add(ingredient);
            }
        }

        private void AllIngredientsLV_OnDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void AllIngredientsLV_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Ingredient ingredient = e.Data.GetData("myFormat") as Ingredient;
                MedIngredients.Remove(ingredient);
                AllIngredients.Add(ingredient);
            }
        }

        private void MedIngredientsLV_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void MedIngredientsLV_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance
                 || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null) return;

                Ingredient ingredient = (Ingredient)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                DataObject dragData = new DataObject("myFormat", ingredient);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void SetButtonVisibility()
        {
            if (idTxt.Text != String.Empty && nameTxt.Text != String.Empty && producerTxt.Text != String.Empty &&
                replacementsCB.SelectedItem != null)
            {
                confirmBTN.IsEnabled = true;
            }
            else
            {
                confirmBTN.IsEnabled = false;
            }
        }

        private void IdTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void NameTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void ProducerTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void ReplacementSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtonVisibility();
        }
    }
}
