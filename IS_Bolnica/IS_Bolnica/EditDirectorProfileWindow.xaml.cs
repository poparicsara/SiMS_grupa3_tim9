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
        private string phone;
        private string email;

        public EditDirectorProfileWindow(String phone, String email)
        {
            InitializeComponent();

            this.phone = phone;
            this.email = email;

            numberBox.Text = phone;
            emailBox.Text = email;

            numberBox.Focusable = true;
            numberBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DirectorProfileWindow profileWindow = new DirectorProfileWindow(phone, email);
                profileWindow.Show();
                this.Close();
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!numberBox.Text.Equals("") && !emailBox.Text.Equals(""))
            {
                DirectorProfileWindow profileWindow = new DirectorProfileWindow(numberBox.Text, emailBox.Text);
                profileWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow(phone, email);
            profileWindow.Show();
            this.Close();
        }
    }
}
