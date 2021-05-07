using IS_Bolnica.Model;
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
    public partial class UrgentOperationOptionsWindow : Window
    {
        private Operation operation = new Operation();
        private Specialization specialization = new Specialization();
        private List<Operation> operationOptions = new List<Operation>();
        private List<Operation> scheduledOperations = new List<Operation>();
        private OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
        private DateTime currentDate = new DateTime();
        private Operation operOption = new Operation();
        private List<Doctor> doctors = new List<Doctor>();
        private DoctorFileStorage doctorFileStorage = new DoctorFileStorage();
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private RoomRecordFileStorage roomFileStorage = new RoomRecordFileStorage();

        public UrgentOperationOptionsWindow(Operation operation, Specialization specialization)
        {
            InitializeComponent();
            this.operation = operation;
            this.specialization = specialization;

            operationOptions = getOperationOptions(operation, specialization);
            OperationOptions.ItemsSource = operationOptions;

        }

        private List<Operation> getOperationOptions(Operation operation, Specialization specialization1)
        {
            List<Operation> options = new List<Operation>();
            doctors = doctorFileStorage.loadFromFile("Doctors.json");
            rooms = roomFileStorage.loadFromFile("Sobe.json");
            scheduledOperations = operationsFileStorage.loadFromFile("operations.json");

            currentDate = DateTime.Now;
            operOption = operation;

            DateTime temp = new DateTime();

            foreach(Doctor doc in doctors)
            {
                if(doc.Specialization.Name.Equals(specialization1.Name))
                {
                    operOption.doctor = doc;
                    
                    foreach(RoomRecord room in rooms)
                    {
                        if(room.Id.Equals(doc.Ordination))
                        {
                            operOption.RoomRecord = room;
                        }
                    }

                    for(int i = 1; i <=90; i++)
                    {
                        temp = currentDate.AddMinutes(i);
                        operOption.Date = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 0);
                        operOption.endTime = operOption.Date.AddMinutes(operOption.DurationInMins);
                        if(isAvailable(scheduledOperations, operOption))
                        {
                            MessageBox.Show("PROSLO " + i.ToString());
                            options.Add(operOption);
                            break;
                        }
                    }
                }
            }

            if(options.Count == 0)
            {
                MessageBox.Show("Lista je prazna");
                foreach(Operation op in scheduledOperations)
                {
                    if(op.doctor.Specialization.Name.Equals(specialization1.Name) && op.Date > currentDate)
                    {
                        options.Add(op);
                    }
                }
            }

            return options;
        }

        private bool idExists(List<Patient> patients, string id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(id))
                {
                    return true;
                }

            }

            MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            return false;

        }

        private bool isPatientFree(List<Operation> operations, Operation op)
        {
            foreach (Operation operation in operations)
            {
                if (operation.Patient.Id == operation.Patient.Id)
                {
                    if (operation.Date <= op.Date && op.Date < operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date < op.endTime && op.endTime <= operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date >= op.Date && operation.endTime <= op.endTime) 
                    { 
                        return false;
                    }

                }

            }

            return true;
        }

        private bool isRoomFree(List<Operation> operations, Operation op)
        {
            foreach (Operation operation in operations)
            {
                if (operation.RoomRecord.Id == op.RoomRecord.Id)
                {
                    if (operation.Date <= op.Date && op.Date < operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date >= op.Date && operation.endTime <= op.endTime)
                    {
                        return false;
                    }

                    if (operation.Date < op.Date && op.endTime <= operation.endTime)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isDoctorFree(List<Operation> operations, Operation op)
        {
            foreach (Operation operation in operations)
            {
                if (operation.doctor.Id == op.doctor.Id)
                {
                    if (operation.Date <= op.Date && op.Date < operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date < op.endTime && op.endTime <= operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date >= op.Date && operation.endTime <= op.endTime)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isAvailable(List<Operation> operations, Operation operation)
        {
            if (operation.Patient != null) {
                if (isPatientFree(operations, operation)
                    && isRoomFree(operations, operation)
                    && isDoctorFree(operations, operation))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                if (isRoomFree(operations,operation)
                    && isDoctorFree(operations, operation))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private void addUrgentExamination(object sender, RoutedEventArgs e)
        {
            int i = OperationOptions.SelectedIndex;
            Operation op = new Operation();
            op = (Operation)OperationOptions.SelectedItem;
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");

            if(i == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju želite da zakažete!");
            }
            else
            {
                foreach(Operation oper in operations)
                {
                    if(oper.Date == op.Date && oper.doctor.Id.Equals(op.doctor.Id))
                    {
                        MessageBox.Show("CONTAINS");

                        operation.Date = op.Date;
                        operation.endTime = operation.Date.AddMinutes(operation.DurationInMins);
                        operation.doctor = op.doctor;
                        operation.RoomRecord = op.RoomRecord;
                        operations.Remove(oper);
                        operations.Add(operation);
                        operationsFileStorage.saveToFile(operations, "operations.json");
                        postponeOperation(oper);
                        return;
                    }
                }
                operations.Add(op);
                MessageBox.Show("Okay");
                operationsFileStorage.saveToFile(operations, "operations.json");
            }

        }

        private void postponeOperation(Operation operation1)
        {
            List<Operation> opers = new List<Operation>();
            opers = operationsFileStorage.loadFromFile("operations.json");

            DateTime dateNew = new DateTime();
            dateNew = operation1.Date;
            DateTime temp = new DateTime();

            MessageBox.Show("Pre for petlje");

            for(int i = 0; i<1000; i++)
            {
                MessageBox.Show("FOR " + i);
                temp = dateNew.AddMinutes(i*10);
                operation1.Date = new DateTime( temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 0);
                operation1.endTime = operation1.Date.AddMinutes(operation1.DurationInMins);
                if(isAvailable(opers, operation1))
                {
                    MessageBox.Show("AVAILABLE");
                    opers.Add(operation1);
                    operationsFileStorage.saveToFile(opers, "operations.json");
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
        }
    }
}
