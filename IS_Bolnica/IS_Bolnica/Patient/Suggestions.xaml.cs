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
    /// <summary>
    /// Interaction logic for Predlozi.xaml
    /// </summary>
    public partial class Suggestions : Window
    {
        public Suggestions(String doktor_name, String doktor_surname, DateTime datum)
        {
            InitializeComponent();
            
            List<Examination> predlozi = new List<Examination>();
            int dan = datum.Day;
            int mesec = datum.Month;
            int godina = datum.Year;

            if (!doktor_name.Equals("") && !doktor_surname.Equals(""))
            {
                Examination ex1 = new Examination();
                Doctor d1 = new Doctor();
                d1.Name = doktor_name;
                d1.Surname = doktor_surname;
                ex1.Doctor = d1;
                ex1.Date = new DateTime(2021, 4, 22, 9, 30, 0);
                predlozi.Add(ex1);

                Examination ex2 = new Examination();
                Doctor d2 = new Doctor();
                d2.Name = doktor_name;
                d2.Surname = doktor_surname;
                ex2.Doctor = d2;
                ex2.Date = new DateTime(2021, 4, 22, 14, 00, 0);
                predlozi.Add(ex2);

                Examination ex3 = new Examination();
                Doctor d3 = new Doctor();
                d3.Name = doktor_name;
                d3.Surname = doktor_surname;
                ex3.Doctor = d3;
                ex3.Date = new DateTime(2021, 4, 23, 8, 00, 0);
                predlozi.Add(ex3);
                
                Examination ex4 = new Examination();
                Doctor d4 = new Doctor();
                d4.Name = doktor_name;
                d4.Surname = doktor_surname;
                ex4.Doctor = d4;
                ex4.Date = new DateTime(2021, 4, 23, 11, 30, 0);
                predlozi.Add(ex4);
            }
            else if (godina != 0001)
            {
                Examination ex1 = new Examination();
                Doctor d1 = new Doctor();
                d1.Name = "Pera";
                d1.Surname = "Peric";
                ex1.Doctor = d1;
                ex1.Date = new DateTime(godina, mesec, dan, 14, 00, 0);
                predlozi.Add(ex1);

                Examination ex2 = new Examination();
                Doctor d2 = new Doctor();
                d2.Name = "Mika";
                d2.Surname = "Mikic";
                ex2.Doctor = d2;
                ex2.Date = new DateTime(godina, mesec, dan, 09, 30, 0); 
                predlozi.Add(ex2);

                Examination ex3 = new Examination();
                Doctor d3 = new Doctor();
                d3.Name = "Mika";
                d3.Surname = "Mikic";
                ex3.Doctor = d3;
                ex3.Date = new DateTime(godina, mesec, dan, 11, 30, 0); 
                predlozi.Add(ex3);

                Examination ex4 = new Examination();
                Doctor d4 = new Doctor();
                d4.Name = "Ziva";
                d4.Surname = "Zivic";
                ex4.Doctor = d4;
                ex4.Date = new DateTime(godina, mesec, dan, 08, 00, 0); 
                predlozi.Add(ex4);
            }
            else {
                Examination ex1 = new Examination();
                Doctor d1 = new Doctor();
                d1.Name = "Pera";
                d1.Surname = "Peric";
                ex1.Doctor = d1;
                ex1.Date = new DateTime(2021, 4, 22, 08, 00, 0);
                predlozi.Add(ex1);
                
                Examination ex2 = new Examination();
                Doctor d2 = new Doctor();
                d2.Name = "Mika";
                d2.Surname = "Mikic";
                ex2.Doctor = d2;
                ex2.Date = new DateTime(2021, 4, 21, 09, 30, 0); 
                predlozi.Add(ex2);

                Examination ex3 = new Examination();
                Doctor d3 = new Doctor();
                d3.Name = "Mika";
                d3.Surname = "Mikic";
                ex3.Doctor = d3;
                ex3.Date = new DateTime(2021, 4, 22, 14, 00, 0);
                predlozi.Add(ex3);

                Examination ex4 = new Examination();
                Doctor d4 = new Doctor();
                d4.Name = "Ziva";
                d4.Surname = "Zivic";
                ex4.Doctor = d4;
                ex4.Date = new DateTime(2021, 4, 21, 08, 00, 0); 
                predlozi.Add(ex4);
            }

            PredloziBinding.ItemsSource = predlozi;
        }

        private void NazadButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
