using Pacientes.Domain.Entities;

namespace Pacientes.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient?> GetByIdAsync(int id);

        Task<Patient> AddAsync(Patient patient);

        Task UpdateAsync(Patient patient);

        Task DeleteAsync(Patient patient);
    }
}
