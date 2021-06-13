using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Secretary.ViewModel;
using IS_Bolnica.Secretary;

namespace IS_Bolnica.GUI.Secretary.View
{
    public partial class SecretaryProfile : Page
    {
        public SecretaryProfile(string username, SekretarWindow window)
        {
            InitializeComponent();
            DataContext = new SecretaryProfileVM(username, window);
        }

    }
}
