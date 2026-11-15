using Pacientes.Domain.Entities;

namespace Pacientes.Application.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient?> GetByIdAsync(int id);

        Task<Patient> CreateAsync(Patient patient);

        Task<bool> UpdateAsync(int id, Patient patient);

        Task<bool> DeleteAsync(int id);
    }
}
