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
        private Inventory newInventory = new Inventory();
        private InventoryFileStorage storage = new InventoryFileStorage();

        public EditInventoryWindow(Inventory selectedInventory)
        {
            InitializeComponent();

            oldInventory = selectedInventory;

            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            idBox.Text = oldInventory.Id.ToString();
            nameBox.Text = oldInventory.Name;
            currentBox.Text = oldInventory.CurrentAmount.ToString();
            minBox.Text = oldInventory.Minimum.ToString();
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewInventory();
            storage.EditInventory(oldInventory, newInventory);
            this.Close();
        }

        private void SetNewInventory()
        {
            newInventory.Id = (int)Int64.Parse(idBox.Text);
            newInventory.Name = nameBox.Text;
            newInventory.CurrentAmount = (int)Int64.Parse(currentBox.Text);
            newInventory.Minimum = (int)Int64.Parse(minBox.Text);
            newInventory.InventoryType = oldInventory.InventoryType;
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
