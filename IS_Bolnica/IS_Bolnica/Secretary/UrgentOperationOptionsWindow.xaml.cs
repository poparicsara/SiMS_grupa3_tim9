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

namespace IS_Bolnica.Secretary
{
    public partial class UrgentOperationOptionsWindow : Window
    {
        private Operation operation = new Operation();
        private Specialization specialization = new Specialization();

        public UrgentOperationOptionsWindow(Operation operation, Specialization specialization)
        {
            InitializeComponent();
            this.operation = operation;
            this.specialization = specialization;

        }
    }
}
