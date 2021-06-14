using System;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.Model;
using IS_Bolnica.Secretary;

namespace IS_Bolnica.GUI.Secretary.ViewModel
{
    class SelectedPatientVM
    {
        public string imeLabel { get; set; }
        public string prezimeLabel { get; set; }
        public string usernameLabel { get; set; }
        public string JMBGLabel { get; set; }
        public string dateLabel { get; set; }
        public string emailLabel { get; set; }
        public string telephoneLabel { get; set; }
        public string genderLabel { get; set; }
        public string addressLabel { get; set; }
        public string cityLabel { get; set; }
        public string countryLabel { get; set; }
        public string allergensLabel { get; set; }

        public SelectedPatientVM(global::Model.Patient patient)
        {
            SetCommands();

            imeLabel = patient.Name;
            prezimeLabel = patient.Surname;
            usernameLabel = patient.Username;
            JMBGLabel = patient.Id;
            dateLabel = patient.DateOfBirth.Day + "." + patient.DateOfBirth.Month + "." +
                        patient.DateOfBirth.Year;
            emailLabel = patient.Email;
            telephoneLabel = patient.Phone;
            if (patient.Gender == Gender.male)
            {
                genderLabel = "Muško";
            }
            else
            {
                genderLabel = "Žensko";
            }
            addressLabel = patient.Address.Street + " "
                                                  + Convert.ToString(patient.Address.NumberOfBuilding) + "/"
                                                  + Convert.ToString(patient.Address.Floor) + "/"
                                                  + Convert.ToString(patient.Address.Apartment);
            cityLabel = patient.Address.City.name + " "
                                                  + Convert.ToString(patient.Address.City.postalCode);
            countryLabel = patient.Address.City.Country.name;
            if (patient.Ingredients != null && patient.Ingredients.Count != 0)
            {
                foreach (var ingredient in patient.Ingredients)
                {
                    allergensLabel += ingredient.Name + "\n";
                }
            }
        }

        public RelayCommand BackButtonCommand { get; private set; }

        private void BackCommand(object parameter)
        {
            SekretarWindow.MyFrame.NavigationService.Navigate(new PatientList(new ActionBar()));
        }

        private void SetCommands()
        {
            BackButtonCommand = new RelayCommand(BackCommand);
        }
    }
}
