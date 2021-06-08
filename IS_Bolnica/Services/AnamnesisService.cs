﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    public class AnamnesisService
    {
        private AnamnesisRepository anamnesisRepository = new AnamnesisRepository();
        private List<Anamnesis> anamneses = new List<Anamnesis>();

        public AnamnesisService()
        {
            anamneses = getAnamneses();
        }

        public List<string> getPatientsDiagnosesFromAnamneses(string patientId)
        {
            List<string> patientsDiagnoses = new List<string>();
            foreach (Anamnesis anamnesis in anamneses)
            {
                if (anamnesis.Patient.Id.Equals(patientId))
                {
                    patientsDiagnoses.Add(anamnesis.Diagnosis);
                }
            }
            return patientsDiagnoses;
        }

        public void createAnamnesis(Anamnesis anamnesis)
        {
            anamneses.Add(anamnesis);
            anamnesisRepository.saveToFile(anamneses, "anamneses.json");
        }

        private List<Anamnesis> getAnamneses()
        {
            return anamnesisRepository.loadFromFile("anamneses.json");
        }

        public List<Anamnesis> getPatientAnamneses(String username) {
            List<Anamnesis> patientAnamneses = new List<Anamnesis>();

            foreach (Anamnesis anamnesis in anamneses) {
                if (anamnesis.Patient.Username.Equals(username))
                    patientAnamneses.Add(anamnesis);
            }

            return patientAnamneses;
        }
    }
}
