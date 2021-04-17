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
    /// Interaction logic for Izmena_pregleda.xaml
    /// </summary>
    public partial class Izmena_pregleda : Window
    {
        private int oznaceniIndex;
        public Izmena_pregleda(int index)
        {
            oznaceniIndex = index;
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

            //2.3.2020. 09:15:00 
            DateTime oznaceniDatum = pregledi.ElementAt(index).date;
            string[] pom = oznaceniDatum.ToString().Split(' ');
            string[] datum = pom[0].Split('/');
            string[] vreme = pom[1].Split(':');
            
            InitializeComponent();

            DoktorBox.Text = pregledi.ElementAt(index).doctor.Name + " " + pregledi.ElementAt(index).doctor.Surname;
            DateTime dat = new DateTime(Int32.Parse(datum[2]), Int32.Parse(datum[0]), Int32.Parse(datum[1]));
            DateBox.SelectedDate = dat;
            
            
            SatiBox.Text = vreme[0];
            MinutiBox.Text = vreme[1];
        }

        private void OdustaniButtonClicked(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e) {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

            Doctor d1 = new Doctor();
            String nameAndSurname = DoktorBox.Text;
            d1.Name = Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            d1.Surname = Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", "");
            DateTime datum = (DateTime) DateBox.SelectedDate;
            int dan = datum.Day;
            int mesec = datum.Month;
            int godina = datum.Year;
            int sati = Convert.ToInt32(SatiBox.Text);
            int minuti = Convert.ToInt32(MinutiBox.Text);
            DateTime datumPregledaNovi = new DateTime(godina, mesec, dan, sati, minuti, 0);

            pregledi.ElementAt(oznaceniIndex).date = datumPregledaNovi;
            pregledi.ElementAt(oznaceniIndex).doctor = d1;
            exStorage.saveToFile(pregledi, "Pregledi.json");
            PatientWindow pw = new PatientWindow();
            pw.Show();
            this.Close();
        }
    }
}
