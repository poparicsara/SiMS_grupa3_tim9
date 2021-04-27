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
    public partial class MedicamentWindow : Window
    {
        public MedicamentWindow()
        {
            InitializeComponent();

            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");

            /*Medicament r1 = new Medicament { Id = 102, Name = "AspirinPlusC", Producer = "Bayer" };
            Medicament m = new Medicament { Name = "Aspirin", Id = 101, Replacement = r1, Producer = "Bayer" };

            List<Medicament> meds = new List<Medicament>();
            meds.Add(m);

            medStorage.saveToFile(meds, "Lekovi.json");*/

            medicamentData.ItemsSource = meds;

        }

        private void Row_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            IngredientWindow iw = new IngredientWindow();
            iw.Show();
            this.Close();
        }

        private void AddMedicamentButton(object sender, RoutedEventArgs e)
        {
            AddMedicamentWindow addMed = new AddMedicamentWindow();
            addMed.Show();
            this.Close();
        }
    }
}
