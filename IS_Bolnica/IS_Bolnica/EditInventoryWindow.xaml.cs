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

    public partial class EditInventoryWindow : Window
    {
        private Inventory oldInventory = new Inventory();
        private Inventory editInventory = new Inventory();

        public EditInventoryWindow(Inventory selectedInventory)
        {
            InitializeComponent();

            oldInventory = selectedInventory;

            idBox.Text = oldInventory.Id.ToString();
            nameBox.Text = oldInventory.Name;
            currentBox.Text = oldInventory.CurrentAmount.ToString();
            minBox.Text = oldInventory.Minimum.ToString();
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            editInventory.Id = (int)Int64.Parse(idBox.Text);
            editInventory.Name = nameBox.Text;
            editInventory.CurrentAmount = (int)Int64.Parse(currentBox.Text);
            editInventory.Minimum = (int)Int64.Parse(minBox.Text);
            editInventory.InventoryType = oldInventory.InventoryType;

            InventoryFileStorage storage = new InventoryFileStorage();
            storage.EditInventory(oldInventory, editInventory);

            this.Close();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
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
