using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Patient.ViewModel;
using IS_Bolnica.PatientPages;

namespace IS_Bolnica.GUI.Patient.View
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();

            DataContext = new ProfileVM();
        }
    }
}
