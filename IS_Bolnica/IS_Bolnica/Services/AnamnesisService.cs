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
            anamneses = GetAnamneses();
        }

        public List<string> GetPatientsDiagnosesFromAnamneses(string patientId)
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

        public void CreateAnamnesis(Anamnesis anamnesis)
        {
            anamneses.Add(anamnesis);
            anamnesisRepository.saveToFile(anamneses, "anamneses.json");
        }

        private List<Anamnesis> GetAnamneses()
        {
            return anamnesisRepository.loadFromFile("anamneses.json");
        }
    }
}
