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
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.DemoMode
{
    public partial class DemoInventoryWindow : Window
    {
        private Inventory selectedInventory = new Inventory();
        private InventoryService service = new InventoryService();

        public DemoInventoryWindow()
        {
            InitializeComponent();

            dynamicDataGrid.ItemsSource = service.GetDynamicInventory();
            staticDataGrid.ItemsSource = service.GetStaticInventory();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void AddDynamicButtonClicked(object sender, RoutedEventArgs e)
        {
            AddInventoryDemo addInventoryWindow = new AddInventoryDemo();
            addInventoryWindow.Show();
            this.Close();
        }

        private void DeleteDynamicButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyDynamicInventorySelected())
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da obrišete izabrani inventar?",
                    "Brisanje inventara", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private bool IsAnyDynamicInventorySelected()
        {
            if (dynamicDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan dinamički inventar!");
                return false;
            }
            else
            {
                selectedInventory = (Inventory)dynamicDataGrid.SelectedItem;
                return true;
            }
        }

        private void EditDynamicButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyDynamicInventorySelected())
            {
                EditInventoryDemo ew = new EditInventoryDemo(selectedInventory);
                ew.Show();
                this.Close();
            }
        }

        private void AddStaticButtonClicked(object sender, RoutedEventArgs e)
        {
            AddInventoryDemo addInventoryWindow = new AddInventoryDemo();
            addInventoryWindow.Show();
            this.Close();
        }

        private void DeleteStaticButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyStaticInventorySelected())
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da obrišete izabrani inventar?",
                    "Brisanje inventara", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private bool IsAnyStaticInventorySelected()
        {
            if (staticDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan statički inventar!");
                return false;
            }
            else
            {
                selectedInventory = (Inventory)staticDataGrid.SelectedItem;
                return true;
            }
        }

        private void EditStaticButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyStaticInventorySelected())
            {
                EditInventoryDemo ew = new EditInventoryDemo(selectedInventory);
                ew.Show();
                this.Close();
            }
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoMedicamentWindow medicamentWindow = new DemoMedicamentWindow();
            medicamentWindow.Show();
            this.Close();
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoRoomWindow uw = new DemoRoomWindow();
            uw.Show();
            this.Close();
        }

        private void SignOutButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
