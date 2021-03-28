using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Interaction logic for Zakazivanje_pregleda.xaml
    /// </summary>
    public partial class Zakazivanje_pregleda : Window
    {
        public Zakazivanje_pregleda()
        {
            InitializeComponent();
        }

        private void ButtonOdustaniClicked(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void ButtonZakaziClicked(object sender, RoutedEventArgs e) {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
            Doctor d1 = new Doctor();
            String nameAndSurname = DoctorCombo.Text;
            d1.name = Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            d1.surname = Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", "");
            DateTime datum = (DateTime) Datum.SelectedDate;
            int dan = datum.Day;
            int mesec = datum.Month;
            int godina = datum.Year;
            int sati = Convert.ToInt32(hourBox.Text);
            int minuti = Convert.ToInt32(minutesBox.Text);
            DateTime datumPregleda = new DateTime(godina, mesec, dan, sati, minuti, 0);

            Examination e1 = new Examination { isPayed = false, durationInMinutes = 30, doctor = d1, date = datumPregleda};
            pregledi.Add(e1);
            exStorage.saveToFile(pregledi, "Pregledi.json");
            PatientWindow pw = new PatientWindow();
            pw.Show();
            this.Close();
        }

        
    }
}
