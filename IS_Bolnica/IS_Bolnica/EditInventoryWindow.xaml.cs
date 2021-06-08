﻿using Model;
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

    public partial class EditInventoryWindow : Window
    {
        private Inventory oldInventory = new Inventory();
        private Inventory newInventory = new Inventory();
        private InventoryService service = new InventoryService();

        public EditInventoryWindow(Inventory selectedInventory)
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
            if (!IsAnythingNull())
            {
                if (SetNewInventory())
                {
                    service.EditInventory(oldInventory, newInventory);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
        }

        private bool IsAnythingNull()
        {
            return idBox.Text.Equals("") || nameBox.Text.Equals("") || currentBox.Text.Equals("") ||
                   minBox.Text.Equals("");
        }

        private bool SetNewInventory()
        {
            if (oldInventory.Id.ToString() != idBox.Text)
            {
                if (service.IsInventoryIdUnique((int)Int64.Parse(idBox.Text)))
                {
                    newInventory.Id = (int)Int64.Parse(idBox.Text);
                    newInventory.Name = nameBox.Text;
                    newInventory.CurrentAmount = (int)Int64.Parse(currentBox.Text);
                    newInventory.Minimum = (int)Int64.Parse(minBox.Text);
                    newInventory.InventoryType = oldInventory.InventoryType;
                    return true;
                }
                else
                {
                    MessageBox.Show("Već postoji inventar sa unetim brojem!");
                    return false;
                }
            }
            else
            {
                newInventory.Id = (int)Int64.Parse(idBox.Text);
                newInventory.Name = nameBox.Text;
                newInventory.CurrentAmount = (int)Int64.Parse(currentBox.Text);
                newInventory.Minimum = (int)Int64.Parse(minBox.Text);
                newInventory.InventoryType = oldInventory.InventoryType;
                return true;
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
