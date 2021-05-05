using IS_Bolnica.Model;
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
    public partial class UpdateMedication : Window
    {
        private Medicament med;
        public UpdateMedication(Medicament medicament)
        {
            InitializeComponent();

            this.med = medicament;

            medIdTxt.Text = med.Id.ToString();
            medNameTxt.Text = med.Name;
            medReplacementTxt.Text = med.Replacement.Name;
            producerTxt.Text = med.Producer;

        }

        private void potvrdiButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");

            for (int i = 0; i < meds.Count; i++)
            {
                if (meds[i].Id.Equals(med.Id))
                {
                    meds.RemoveAt(i);
                }
            }

            med.Id = Convert.ToInt32(medIdTxt.Text);
            med.Name = medNameTxt.Text;
            med.Replacement.Name = medReplacementTxt.Text;
            med.Producer = producerTxt.Text;

            meds.Add(med);

            medStorage.saveToFile(meds, "Lekovi.json");

            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }

        private void odustaniButtonClicked(object sender, RoutedEventArgs e)
        {
            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }
    }
}
