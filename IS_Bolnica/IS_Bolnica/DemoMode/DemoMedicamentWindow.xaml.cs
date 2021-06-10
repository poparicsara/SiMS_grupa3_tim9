using System;
using System.Collections.Generic;
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
using Model;

namespace IS_Bolnica.DemoMode
{

    public partial class DemoMedicamentWindow : Window
    {
        private Request request = new Request();
        private RequestService requestService = new RequestService();
        private Medicament selectedMedicament = new Medicament();
        private MedicamentService medService = new MedicamentService();

        public DemoMedicamentWindow()
        {
            InitializeComponent();

            medicamentDataGrid.ItemsSource = medService.GetMedicaments();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddMedDemo addMed = new AddMedDemo();
            addMed.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyMedicamentSelected())
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da pošaljete zahtev za brisanje leka",
                "Brisanje leka", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private bool IsAnyMedicamentSelected()
        {
            if (medicamentDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan lek!");
                return false;
            }
            else
            {
                selectedMedicament = (Medicament)medicamentDataGrid.SelectedItem;
                return true;
            }
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyMedicamentSelected())
            {
                EditMedDemo ew = new EditMedDemo(selectedMedicament);
                ew.Show();
                this.Close();
            }
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoInventoryWindow iw = new DemoInventoryWindow();
            iw.Show();
            this.Close();
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoRoomWindow uw = new DemoRoomWindow();
            uw.Show();
            this.Close();
        }

        private void SingOutButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
