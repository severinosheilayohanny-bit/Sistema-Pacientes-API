namespace Pacientes.Domain.Entities
{
    public class PrescriptionDetail
    {
        public int Id { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int DurationDays { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } = null!;

        public int MedicationId { get; set; }
        public Medication Medication { get; set; } = null!;
    }
}
