using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WCS_Test_Backend.Models;

namespace WCS_Test_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionsController : ControllerBase
    {
        private readonly Connection _context;

        public AdmissionsController(Connection context)
        {
            _context = context;
        }

        // GET: api/Admissions
        // Devuelve una lista con todos los registros de admisión
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admission>>> GetAdmissions()
        {
            return await _context.Admissions.ToListAsync();
        }

        // GET: api/Admissions/5
        // Recupera una solicitud de admisión según su Id.
        [HttpGet("{id}")]
        public async Task<ActionResult<Admission>> GetAdmission(long id)
        {
            var admission = await _context.Admissions.FindAsync(id);

            if (admission == null)
            {
                return NotFound();
            }

            return admission;
        }

        // PUT: api/Admissions/5
        // Actualiza una solicitud de admisión existente según el Id indicando.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmission(long id, Admission admission)
        {
            if (id != admission.Id)
            {
                return BadRequest();
            }

            _context.Entry(admission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admissions
        // Crea un nuevo registro de admisión y devuelve el registro creado si 
        // el proceso fue exitoso.
        [HttpPost]
        public async Task<ActionResult<Admission>> PostAdmission(Admission admission)
        {
            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmission", new { id = admission.Id }, admission);
        }

        // DELETE: api/Admissions/5
        // Elimina una solicitud de admisión existente según el Id indicando.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmission(long id)
        {
            var admission = await _context.Admissions.FindAsync(id);
            if (admission == null)
            {
                return NotFound();
            }

            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmissionExists(long id)
        {
            return _context.Admissions.Any(e => e.Id == id);
        }
    }
}
