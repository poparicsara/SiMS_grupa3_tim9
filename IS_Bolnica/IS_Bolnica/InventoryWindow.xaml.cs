﻿using Model;
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

    public partial class InventoryWindow : Window
    {
        public InventoryWindow()
        {
            InitializeComponent();

            InventoryFileStorage storage = new InventoryFileStorage();
            List<Inventory> all = storage.GetAll();
            inventoryBinding.ItemsSource = all;
        }
    }
}