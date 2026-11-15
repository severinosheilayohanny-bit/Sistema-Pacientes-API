using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacientes.Application.Interfaces;
using Pacientes.Domain.Entities;

namespace Pacientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/patients
        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/patients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
                return NotFound("Paciente no encontrado.");

            return Ok(patient);
        }

        // POST: api/patients
        [HttpPost]
        public async Task<ActionResult<Patient>> Create(
            [FromBody] Patient patient)
        {
            try
            {
                var createdPatient =
                    await _patientService.CreateAsync(patient);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdPatient.Id },
                    createdPatient);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException)
            {
                return Conflict(
                    "No se pudo registrar el paciente. Verifica que la cédula no esté duplicada.");
            }
        }

        // PUT: api/patients/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id, [FromBody] Patient patient)
        {
            try
            {
                var updated =
                    await _patientService.UpdateAsync(id, patient);

                if (!updated)
                    return NotFound("Paciente no encontrado.");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException)
            {
                return Conflict(
                    "No se pudo actualizar el paciente. Verifica que la cédula no esté duplicada.");
            }
        }

        // DELETE: api/patients/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _patientService.DeleteAsync(id);

                if (!deleted)
                    return NotFound("Paciente no encontrado.");

                return NoContent();
            }
            catch (DbUpdateException)
            {
                return Conflict(
                    "No se puede eliminar el paciente porque tiene registros relacionados.");
            }
        }
    }
}
