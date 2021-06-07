using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace IS_Bolnica
{

    public partial class AddInventoryWindow : Window
    {
        private Inventory inventory = new Inventory();
        private String type;
        private InventoryService service = new InventoryService();

        public AddInventoryWindow(String inventoryType)
        {
            InitializeComponent();

            type = inventoryType;

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewInventory();
            service.AddInventory(inventory);
            this.Close();
        }

        private void SetNewInventory()
        {
            inventory.Id = (int)Int64.Parse(idBox.Text);
            inventory.Name = nameBox.Text;
            inventory.CurrentAmount = (int)Int64.Parse(currentBox.Text);
            inventory.Minimum = (int)Int64.Parse(minBox.Text);
            SetInventoryType();
        }

        private void SetInventoryType()
        {
            if (type.Equals("dinamicki"))
            {
                inventory.InventoryType = Model.InventoryType.dinamicki;
            }
            else if (type.Equals("staticki"))
            {
                inventory.InventoryType = Model.InventoryType.staticki;
            }
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow();
            iw.Show();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
