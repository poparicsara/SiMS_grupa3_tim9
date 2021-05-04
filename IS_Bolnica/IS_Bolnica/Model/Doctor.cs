namespace Model
{
    public class Doctor : Employee
    {
        public Specialization Specialization { get; set; }
        public int Ordination { get; set; }

    }
}