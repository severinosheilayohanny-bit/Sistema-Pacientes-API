namespace Pacientes.Domain.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
