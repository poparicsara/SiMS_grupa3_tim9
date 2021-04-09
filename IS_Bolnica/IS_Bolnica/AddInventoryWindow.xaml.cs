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

        public AddInventoryWindow()
        {
            InitializeComponent();
        }

        private void DoneClicked(object sender, RoutedEventArgs e)
        {
            inventory.Id = (int)Int64.Parse(idBox.Text);
            inventory.Name = nameBox.Text;
            inventory.CurrentAmount = (int)Int64.Parse(currentBox.Text);
            inventory.Minimum = (int)Int64.Parse(minBox.Text);

            InventoryFileStorage storage = new InventoryFileStorage();
            storage.AddInventory(inventory);

            this.Close();
        }


        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InventarWindow iw = new InventarWindow();
            iw.Show();
        }

    }
}
