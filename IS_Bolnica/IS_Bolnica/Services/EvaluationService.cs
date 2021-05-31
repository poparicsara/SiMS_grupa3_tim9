using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IS_Bolnica.Services
{
    class EvaluationService
    {
        EvaluationFileStorage evaluationRepository = new EvaluationFileStorage();
        PrescriptionRepository prescriptionRepository = new PrescriptionRepository();

        public EvaluationService() 
        {

        }

        public List<Evaluation> getEvaluations() {
            return evaluationRepository.loadFromFile("Ocene.json");
        }

        public List<Evaluation> getPatientNotes() {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile("Ocene.json");
            List<Evaluation> patientNotes = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations) {

                if (evaluation.Patient.Username.Equals(PatientWindow.username_patient) && evaluation.commentType == 2)
                    patientNotes.Add(evaluation);

            }

            return patientNotes;
        }

        public void addNote(Evaluation evaluation) {
            List<Evaluation> evaluations = getEvaluations();
            evaluations.Add(evaluation);
            evaluationRepository.saveToFile(evaluations, "Ocene.json");
        }

        public List<Evaluation> getPatientEvaluationsOfAppointment() {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile("Ocene.json");
            List<Evaluation> patientEvaluations = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations)
            {

                if (evaluation.Patient.Username.Equals(PatientWindow.username_patient) && evaluation.commentType == 0)
                    patientEvaluations.Add(evaluation);

            }

            return patientEvaluations;
        }

        public List<Evaluation> getPatientEvaluationsOfHospital()
        {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile("Ocene.json");
            List<Evaluation> patientEvaluations = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations)
            {

                if (evaluation.Patient.Username.Equals(PatientWindow.username_patient) && evaluation.commentType == 1)
                    patientEvaluations.Add(evaluation);

            }

            return patientEvaluations;
        }


    }
}
