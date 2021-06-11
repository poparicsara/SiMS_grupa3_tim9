using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class EvaluationService
    {
        EvaluationRepository evaluationRepository = new EvaluationRepository();
        PrescriptionRepository prescriptionRepository = new PrescriptionRepository();

        public EvaluationService()
        {

        }

        public List<Evaluation> getEvaluations()
        {
            return evaluationRepository.loadFromFile();
        }

        public List<Evaluation> getPatientNotes()
        {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile();
            List<Evaluation> patientNotes = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations)
            {

                if (evaluation.Patient.Username.Equals(PatientWindow.loggedPatient.Username) && evaluation.commentType == 2)
                    patientNotes.Add(evaluation);

            }

            return patientNotes;
        }

        public void addNote(Evaluation evaluation)
        {
            List<Evaluation> evaluations = getEvaluations();
            evaluations.Add(evaluation);
            evaluationRepository.saveToFile(evaluations);
        }

        public List<Evaluation> getPatientEvaluationsOfAppointment()
        {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile();
            List<Evaluation> patientEvaluations = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations)
            {

                if (evaluation.Patient.Username.Equals(PatientWindow.loggedPatient.Username) && evaluation.commentType == 0)
                    patientEvaluations.Add(evaluation);

            }

            return patientEvaluations;
        }

        public List<Evaluation> getPatientEvaluationsOfHospital()
        {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile();
            List<Evaluation> patientEvaluations = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations)
            {

                if (evaluation.Patient.Username.Equals(PatientWindow.loggedPatient.Username) && evaluation.commentType == 1)
                    patientEvaluations.Add(evaluation);

            }

            return patientEvaluations;
        }

        public Boolean checkNote(String text)
        {
            if (!text.Equals(""))
                return true;
            return false;
        }

    }
}
