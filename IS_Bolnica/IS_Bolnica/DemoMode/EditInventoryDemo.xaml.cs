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
using Model;

namespace IS_Bolnica.DemoMode
{

    public partial class EditInventoryDemo : Window
    {
        private Inventory oldInventory = new Inventory();
        private Inventory newInventory = new Inventory();
        private InventoryService service = new InventoryService();

        public EditInventoryDemo(Inventory selectedInventory)
        {
            InitializeComponent();

            oldInventory = selectedInventory;

            FillTextBoxes();

            idBox.Focusable = true;
            idBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
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
            this.Close();
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DemoInventoryWindow iw = new DemoInventoryWindow();
            iw.Show();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
