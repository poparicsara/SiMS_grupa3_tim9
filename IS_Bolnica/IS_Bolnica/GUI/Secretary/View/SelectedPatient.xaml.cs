using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Secretary.ViewModel;
using IS_Bolnica.Secretary;
using IS_Bolnica.Model;


namespace IS_Bolnica.GUI.Secretary.View
{
    public partial class SelectedPatient : Page
    {
        private Page previousPage;
        private global::Model.Patient patient = new global::Model.Patient();

        public SelectedPatient(Page previousPage, global::Model.Patient patient)
        {
            InitializeComponent();
            DataContext = new SelectedPatientVM(patient);
        }

    }
}
