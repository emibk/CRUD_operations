namespace Examen.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; } =DateTime.Now;
        public Grupa Grupa { get; set; }
        public int GrupaId { get; set; }

    }
}
