namespace Pacientes.Domain.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;
        public string Instructions { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
    }
}
