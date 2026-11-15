namespace Pacientes.Domain.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DiagnosisDate { get; set; } = DateTime.Now;

        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;
    }
}
