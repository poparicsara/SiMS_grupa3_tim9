using Model;
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

namespace IS_Bolnica
{

    public partial class AddInventoryWindow : Window
    {
        private Inventory inventory = new Inventory();
        private String type;
        private InventoryRepository storage = new InventoryRepository();

        public AddInventoryWindow(String inventoryType)
        {
            InitializeComponent();

            type = inventoryType;
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewInventory();
            storage.AddInventory(inventory);
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

    }
}
