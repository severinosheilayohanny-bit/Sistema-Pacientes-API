using Pacientes.Application.Interfaces;
using Pacientes.Domain.Entities;
using Pacientes.Domain.Interfaces;

namespace Pacientes.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.FirstName) ||
                string.IsNullOrWhiteSpace(patient.LastName) ||
                string.IsNullOrWhiteSpace(patient.Identification))
            {
                throw new ArgumentException(
                    "El nombre, apellido y cédula son obligatorios.");
            }

            return await _patientRepository.AddAsync(patient);
        }

        public async Task<bool> UpdateAsync(int id, Patient patient)
        {
            var existingPatient = await _patientRepository.GetByIdAsync(id);

            if (existingPatient == null)
                return false;

            if (string.IsNullOrWhiteSpace(patient.FirstName) ||
                string.IsNullOrWhiteSpace(patient.LastName) ||
                string.IsNullOrWhiteSpace(patient.Identification))
            {
                throw new ArgumentException(
                    "El nombre, apellido y cédula son obligatorios.");
            }

            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.Identification = patient.Identification;
            existingPatient.BirthDate = patient.BirthDate;
            existingPatient.Phone = patient.Phone;
            existingPatient.Address = patient.Address;

            await _patientRepository.UpdateAsync(existingPatient);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
                return false;

            await _patientRepository.DeleteAsync(patient);

            return true;
        }
    }
}
