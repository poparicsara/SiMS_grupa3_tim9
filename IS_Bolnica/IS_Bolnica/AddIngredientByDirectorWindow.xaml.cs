using IS_Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using IS_Bolnica.Director.ViewModel;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class AddIngredientByDirectorWindow : Window
    {
        private AddIngredientViewModel viewModel;

        public AddIngredientByDirectorWindow(Medicament selected)
        {
            viewModel = new AddIngredientViewModel(selected);
            InitializeComponent();
            this.DataContext = viewModel;
        }

    }
}
