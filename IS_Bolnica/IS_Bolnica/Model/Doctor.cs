namespace Model
{
    public class Doctor : Employee
    {
        public Specialization specialization { get; set; }
        public int Ordination { get; set; }

    }
}