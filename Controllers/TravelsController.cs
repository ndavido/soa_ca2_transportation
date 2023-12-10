using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soa_ca2.Models;
using soa_ca2.Models.DTOs;
using soa_ca2.Models.NewFolder;

namespace soa_ca2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly TravelContext _context;

        public TravelsController(TravelContext context)
        {
            _context = context;
        }

        // GET: api/Travels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelDTO>>> GetTravel()
        {
            if (_context.Travel == null)
            {
                return NotFound();
            }
            var travels = await _context.Travel.Include(t => t.Schedules).ToListAsync();

            var travelDTOs = travels.Select(t => new TravelDTO
            {
                TravelID = t.TravelID,
                TravelName = t.TravelName,
                StartLocation = t.StartLocation,
                EndLocation = t.EndLocation,
                Schedules = t.Schedules.Select(s => new ScheduleDTO
                {
                    ScheduleID = s.ScheduleID
                }).ToList()
            }).ToList();

            return travelDTOs;
        }

        // GET: api/Travels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelDTO>> GetTravel(int id)
        {
            if (_context.Travel == null)
            {
                return NotFound();
            }
            // Include the related Schedules data
            var travel = await _context.Travel.Include(t => t.Schedules).FirstOrDefaultAsync(t => t.TravelID == id);

            if (travel == null)
            {
                return NotFound();
            }

            var travelDTO = new TravelDTO
            {
                TravelID = travel.TravelID,
                TravelName = travel.TravelName,
                StartLocation = travel.StartLocation,
                EndLocation = travel.EndLocation,
                Schedules = travel.Schedules.Select(s => new ScheduleDTO // Assuming ScheduleDTO is defined
                {
                    ScheduleID = s.ScheduleID,
                    // Map other Schedule properties
                }).ToList()
            };

            return travelDTO;
        }


        // PUT: api/Travels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravel(int id, TravelDTO travelDTO)
        {
            if (id != travelDTO.TravelID)
            {
                return BadRequest();
            }

            var travel = new Travel
            {
                TravelID = travelDTO.TravelID,
                TravelName = travelDTO.TravelName,
                StartLocation = travelDTO.StartLocation,
                EndLocation = travelDTO.EndLocation
            };

            _context.Entry(travel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExists(id))
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

        // POST: api/Travels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelDTO>> PostTravel(TravelDTO travelDTO)
        {
            if (_context.Travel == null)
            {
                return Problem("Entity set 'TravelContext.Travel'  is null.");
            }

            var travel = new Travel
            {
                TravelName = travelDTO.TravelName,
                StartLocation = travelDTO.StartLocation,
                EndLocation = travelDTO.EndLocation
            };

            _context.Travel.Add(travel);
            await _context.SaveChangesAsync();

            travelDTO.TravelID = travel.TravelID;
            return CreatedAtAction("GetTravel", new { id = travel.TravelID }, travelDTO);
        }

        // DELETE: api/Travels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            if (_context.Travel == null)
            {
                return NotFound();
            }
            var travel = await _context.Travel.FindAsync(id);
            if (travel == null)
            {
                return NotFound();
            }

            _context.Travel.Remove(travel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelExists(int id)
        {
            return (_context.Travel?.Any(e => e.TravelID == id)).GetValueOrDefault();
        }
    }
}
