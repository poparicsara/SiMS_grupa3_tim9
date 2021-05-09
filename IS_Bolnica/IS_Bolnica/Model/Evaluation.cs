namespace Model
{
    public class Evaluation
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public string Comment { get; set; }
        public int Assessment { get; set; }
        public string Bolnica { get; set; }
    }
}