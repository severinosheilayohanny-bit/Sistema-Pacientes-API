namespace Pacientes.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}
