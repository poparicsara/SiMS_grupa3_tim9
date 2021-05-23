using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for ExaminationListWindow.xaml
    /// </summary>
    public partial class ExaminationListWindow : Window, INotifyPropertyChanged
    {
        public List<Examination> Pregledi { get; set; }
        ExaminationsRecordFileStorage examinationFileStorage = new ExaminationsRecordFileStorage();
        private Examination examination =  new Examination();

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public ExaminationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = examinationFileStorage.loadFromFile("Pregledi.json");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            Secretary.AddExaminationWindow aew = new Secretary.AddExaminationWindow();
            aew.Show();
            this.Close();
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = ExaminationList.SelectedIndex;

            Examination examination = (Examination)ExaminationList.SelectedItem;

            if(i==-1)
            {
                MessageBox.Show("Niste izabrali pregled koji želite da izmenite!");
            }
            else
            {
                Secretary.EditExaminationWindow eew = new Secretary.EditExaminationWindow(examination);
                setElementsEEW(eew, examination);

                eew.Show();
                this.Close();

            }
        }

        private void setElementsEEW(EditExaminationWindow eew, Examination examination)
        {
            eew.idPatientBox.Text = examination.Patient.Id;
            eew.hourBox.Text = examination.Date.Hour.ToString();
            eew.minutesBox.Text = examination.Date.Minute.ToString();
            eew.doctorBox.Text = examination.Doctor.Name + " " + examination.Doctor.Surname;
            eew.dateBox.SelectedDate = new DateTime(examination.Date.Year, examination.Date.Month, examination.Date.Day);
            eew.durationInMinutesBox.Text = "30";
        }

        private bool isSelected(int i)
        {
            if(i == -1)
            {
                return false;
            } else
            {
                return true;
            }
        }

        private void deleteExamination(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = ExaminationList.SelectedIndex;

            examination = (Examination)ExaminationList.SelectedItem;

            if(!isSelected(i))
            {
                MessageBox.Show("Niste izabrali pregled koji želite da obrišete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da izbrišete", "Brisanje pregleda", MessageBoxButton.YesNo);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        Pregledi = removeExamination(examination);
                        examinationFileStorage.saveToFile(Pregledi, "Pregledi.json");
                        this.Close();
                        Secretary.ExaminationListWindow elw = new Secretary.ExaminationListWindow();
                        elw.Show();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private List<Examination> removeExamination(Examination examination)
        {
            Pregledi = examinationFileStorage.loadFromFile("Pregledi.json");
            for (int k = 0; k < Pregledi.Count; k++)
            {
                if (Pregledi[k].Date.Equals(examination.Date) &&
                    Pregledi[k].Patient.Id.Equals(examination.Patient.Id))
                {
                    Pregledi.RemoveAt(k);
                }
            }

            return Pregledi;
        }


    }
}
