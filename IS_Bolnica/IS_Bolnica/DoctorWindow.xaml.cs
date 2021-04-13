using IS_Bolnica.DoctorsWindows;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            ExaminationsRecordFileStorage examinationFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationFileStorage.loadFromFile("examinations.json");

            dataGridExaminations.ItemsSource = examinations;

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");

            dataGridOperations.ItemsSource = operations;
        }

        private void addExaminationButton(object sender, RoutedEventArgs e)
        {
            AddExaminationWindow addExaminationWindow = new AddExaminationWindow();
            addExaminationWindow.Show();
            this.Close();

        }

        private void addOperationButton(object sender, RoutedEventArgs e)
        {
            AddOperationWindow addOperationWindow = new AddOperationWindow();
            addOperationWindow.Show();
            this.Close();
        }

        private void cancelExaminationButton(object sender, RoutedEventArgs e)
        {
            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");
            examinations.RemoveAt(dataGridExaminations.SelectedIndex);
            examinationsRecordFileStorage.saveToFile(examinations, "examinations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelOperationButton(object sender, RoutedEventArgs e)
        {
            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");
            operations.RemoveAt(dataGridOperations.SelectedIndex);
            operationsFileStorage.saveToFile(operations, "operations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
            this.Close();
        }

        private void updateExaminationButton(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            UpdateExaminationWindow updateExaminationWindow = new UpdateExaminationWindow(selectedIndex);
            updateExaminationWindow.Show();
            this.Close();
        }

        private void updateOperationButton(object sender, RoutedEventArgs e)
        {
           int selectedIndex = dataGridOperations.SelectedIndex;
           UpdateOperationWindow updateOperationWindow = new UpdateOperationWindow(selectedIndex);
           updateOperationWindow.Show();
           this.Close();
        }

        private void startExamination(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            ExaminationInfo examinationInfo = new ExaminationInfo(selectedIndex);
            examinationInfo.Show();
        }
    }
}
