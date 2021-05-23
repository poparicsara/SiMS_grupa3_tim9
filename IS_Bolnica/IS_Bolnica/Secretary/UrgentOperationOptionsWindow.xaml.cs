﻿using IS_Bolnica.Model;
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
        private Examination examination = new Examination();
        private List<Examination> examinations = new List<Examination>();
        private ExaminationsRecordFileStorage examinationsFileStorage = new ExaminationsRecordFileStorage();



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
                        examinations = examinationsFileStorage.loadFromFile("Pregledi.json");
                        examination.Date = operOption.Date;
                        examination.DurationInMinutes = operOption.DurationInMins;
                        examination.Patient = operOption.Patient;
                        examination.Doctor = operOption.doctor;
                        examination.RoomRecord = operOption.RoomRecord;
                        if (isAvailable(scheduledOperations, operOption) && isAvailableEx(examinations, examination))
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
                MessageBox.Show("Nema slobodnih termina, morate da odložite");
                foreach(Operation op in scheduledOperations)
                {
                    if(op.doctor.Specialization.Name.Equals(specialization1.Name) && op.Date > currentDate)
                    {
                        op.PosponedDate = setPostponedDate(op).PosponedDate;
                        options.Add(op);
                    }
                }
                options = sortByPostponeDates(options);
            }

            return options;
        }

        private Operation setPostponedDate(Operation operation1)
        {
            List<Operation> opers = new List<Operation>();
            opers = operationsFileStorage.loadFromFile("operations.json");

            DateTime dateNew = new DateTime();
            dateNew = operation1.Date;
            DateTime temp = new DateTime();

            MessageBox.Show("Pre for petlje");

            for (int i = 0; i < 1000; i++)
            {
                temp = dateNew.AddMinutes(i * 10);
                operation1.PosponedDate = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 0);
                if (isAvailablePosponed(opers, operation1))
                {
                    break;
                }
            }
            return operation1;
        }

        private List<Operation> sortByPostponeDates(List<Operation> operations) 
        {
            List<Operation> orderedOperations = new List<Operation>();
            DateTime minDate = new DateTime();

            while(operations.Count != 0)
            {
                minDate = operations[0].PosponedDate;
                foreach(Operation op in operations)
                {
                    if(minDate >= op.PosponedDate)
                    {
                        minDate = op.PosponedDate;
                    }
                }

                for(int i = 0; i < operations.Count; i++)
                {
                    if(minDate == operations[i].PosponedDate)
                    {
                        orderedOperations.Add(operations[i]);
                        operations.RemoveAt(i);
                    }
                }
            }

            return orderedOperations;
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

        private bool isPatientFreePostponed(List<Operation> operations, Operation op)
        {
            DateTime postponeEnd = op.PosponedDate.AddMinutes(op.DurationInMins);
            foreach (Operation operation in operations)
            {
                if (operation.Patient.Id == operation.Patient.Id)
                {
                    if (operation.Date <= op.PosponedDate && op.PosponedDate < operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date < postponeEnd && postponeEnd <= operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date >= op.PosponedDate && operation.endTime <= postponeEnd)
                    {
                        return false;
                    }

                }

            }

            return true;
        }

        private bool isRoomFreePostponed(List<Operation> operations, Operation op)
        {
            DateTime postponeEnd = op.PosponedDate.AddMinutes(op.DurationInMins);
            foreach (Operation operation in operations)
            {
                if (operation.RoomRecord.Id == op.RoomRecord.Id)
                {
                    if (operation.Date <= op.PosponedDate && op.PosponedDate < operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date >= op.PosponedDate && operation.endTime <= postponeEnd)
                    {
                        return false;
                    }

                    if (operation.Date < op.PosponedDate && postponeEnd <= operation.endTime)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isDoctorFreePostponed(List<Operation> operations, Operation op)
        {
            DateTime postponeEnd = op.PosponedDate.AddMinutes(op.DurationInMins);
            foreach (Operation operation in operations)
            {
                if (operation.doctor.Id == op.doctor.Id)
                {
                    if (operation.Date <= op.PosponedDate && op.PosponedDate < operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date < postponeEnd && postponeEnd <= operation.endTime)
                    {
                        return false;
                    }

                    if (operation.Date >= op.PosponedDate && operation.endTime <= postponeEnd)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isAvailablePosponed(List<Operation> operations, Operation operation)
        {
            if (operation.Patient != null)
            {
                if (isPatientFreePostponed(operations, operation)
                    && isRoomFreePostponed(operations, operation)
                    && isDoctorFreePostponed(operations, operation))
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
                if (isRoomFreePostponed(operations, operation)
                    && isDoctorFreePostponed(operations, operation))
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
            List<Operation> ops = new List<Operation>();
            ops = OperationOptions.SelectedItems.Cast<Operation>().ToList();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");

            if (i == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju želite da zakažete!");
            }
            else
            {
                for (int k = 0; k < operations.Count; k++)
                {
                    if (ops.Count == 1) 
                    {
                        if (operations[k].Date == ops[0].Date && operations[k].doctor.Id.Equals(ops[0].doctor.Id))
                        {
                            if(ops[0].DurationInMins < operation.DurationInMins)
                            {
                                MessageBox.Show("Operacije koju ste izabrali nije dovoljno duga, izaberite još!");
                                return;
                            }
                            MessageBox.Show("CONTAINS");

                            operation.Date = ops[0].Date;
                            operation.endTime = operation.Date.AddMinutes(operation.DurationInMins);
                            operation.doctor = ops[0].doctor;
                            operation.RoomRecord = ops[0].RoomRecord;
                            operations.RemoveAt(k);
                            operations.Add(operation);
                            operationsFileStorage.saveToFile(operations, "operations.json");
                            postponeOperation(ops[0], operations);
                            return;
                        }
                    }
                }

                if (ops.Count > 1)
                {
                    int duration = 0;
                    foreach(Operation o in ops)
                    {
                        duration += o.DurationInMins;
                    }

                    if(duration < operation.DurationInMins)
                    {
                        MessageBox.Show("Operacije koje ste izabrali nisu dovoljno dugačke, izaberite još!");
                        return;
                    }

                    operation.Date = ops[0].Date;
                    operation.endTime = operation.Date.AddMinutes(operation.DurationInMins);
                    operation.doctor = ops[0].doctor;
                    operation.RoomRecord = ops[0].RoomRecord;
                    for (int k = 0; k<operations.Count; k++)
                    {
                        if(operations[k].Date.Equals(ops[0].Date) && operations[k].doctor.Id.Equals(ops[0].doctor.Id))
                        {
                            operations.RemoveAt(k);
                        }
                    }
                    operations.Add(operation);
                    operationsFileStorage.saveToFile(operations, "operations.json");
                    postponeOperation(ops[0], operations);

                    for(int k = 1; k < ops.Count; k++)
                    {
                        for (int j = 0; j < operations.Count; j++)
                        {
                            if (operations[j].Date.Equals(ops[k].Date) && operations[j].doctor.Id.Equals(ops[k].doctor.Id))
                            {
                                operations.RemoveAt(j);
                                MessageBox.Show("OKKKKKKKKKK");
                            }
                        }
                        postponeOperation(ops[k], operations);
                    }
                    return;
                }


                operations.Add(ops[0]);
                MessageBox.Show("Okay");
                operationsFileStorage.saveToFile(operations, "operations.json");
            }

        }

        private void postponeOperation(Operation operation1, List<Operation> operations)
        {
            DateTime dateNew = new DateTime();
            dateNew = operation1.Date;
            DateTime temp = new DateTime();

            MessageBox.Show("Pre for petlje");

            for(int i = 0; i<1000000; i++)
            {
                temp = dateNew.AddMinutes(i*10);
                operation1.Date = new DateTime( temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 0);
                operation1.endTime = operation1.Date.AddMinutes(operation1.DurationInMins);

                examinations = examinationsFileStorage.loadFromFile("Pregledi.json");
                examination.Date = operation1.Date;
                examination.DurationInMinutes = operation1.DurationInMins;
                examination.Patient = operation1.Patient;
                examination.Doctor = operation1.doctor;
                examination.RoomRecord = operation1.RoomRecord;
                if (isAvailable(operations, operation1) && isAvailableEx(examinations, examination))
                {
                    MessageBox.Show("AVAILABLE");
                    operations.Add(operation1);
                    operationsFileStorage.saveToFile(operations, "operations.json");
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



        private bool isPatientFreeEx(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(ex.DurationInMinutes);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Patient.Id == ex.Patient.Id && exam.Date == ex.Date)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime < endTimeNew)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }
                }

            }

            return true;
        }

        private bool isRoomFreeEx(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(ex.DurationInMinutes);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.RoomRecord.Id == ex.RoomRecord.Id)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        MessageBox.Show("Soba " + ex.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Soba " + ex.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime < endTimeNew)
                    {
                        MessageBox.Show("Soba " + ex.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFreeEx(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(ex.DurationInMinutes);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Doctor.Id == ex.Doctor.Id && exam.Date == ex.Date)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime <= endTimeNew)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isAvailableEx(List<Examination> exams, Examination ex)
        {
            if (isPatientFreeEx(exams, ex) && isRoomFreeEx(exams, ex) && isDoctorFreeEx(exams, ex))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
