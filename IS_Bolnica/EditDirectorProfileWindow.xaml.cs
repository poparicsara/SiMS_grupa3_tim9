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
    public partial class EditDirectorProfileWindow : Window
    {
        private User user = new User();

        public EditDirectorProfileWindow()
        {
            InitializeComponent();
        }

        private void setInfo()
        {
            user.Id = "60";
            user.Name = "Ivan";
            user.Surname = "Ivanovic";
            user.Phone = "0601234567";
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void getInfo()
        {
            user.Surname = SurnameBox.Text;            
        }
    }
}
