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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for AddOperationWindow.xaml
    /// </summary>
    public partial class AddOperationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Operation operation = new Operation();
        private List<Operation> Operations = new List<Operation>();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();


        public AddOperationWindow()
        {
            InitializeComponent();
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                RoomNums.Add(Rooms[i].Id);
            }
            room.ItemsSource = RoomNums;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            Operations = operationStorage.loadFromFile("operations.json");

            List<String> doctors = (List<string>) doctorList.SelectedItems;
            for(int i = 0; i < doctors.Count; i++)
            {
                string[] docNameAndSurname = doctors[i].Split(' '); 
                Doctor doc = new Doctor();
                doc.Name = docNameAndSurname[0];
                doc.Surname = docNameAndSurname[1];
                operation.doctor.Add(doc);
            }






            




            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }

        private void cancelAddingOperation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
