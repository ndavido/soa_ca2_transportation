using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soa_ca2.Models;
using soa_ca2.Models.DTOs;

namespace soa_ca2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly TravelContext _context;

        public SchedulesController(TravelContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetSchedule()
        {
            if (_context.Schedule == null)
            {
                return NotFound();
            }
            // Include the related Travel data
            var schedules = await _context.Schedule.Include(s => s.Travel).ToListAsync();

            var scheduleDTOs = schedules.Select(s => new ScheduleDTO
            {
                ScheduleID = s.ScheduleID,
                TravelID = s.TravelID,
                DepartureTime = s.DepartureTime,
                ArrivalTime = s.ArrivalTime
            }).ToList();

            return scheduleDTOs;
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDTO>> GetSchedule(int id)
        {
            if (_context.Schedule == null)
            {
                return NotFound();
            }
            // Include the related Travel data
            var schedule = await _context.Schedule.Include(s => s.Travel).FirstOrDefaultAsync(s => s.ScheduleID == id);

            if (schedule == null)
            {
                return NotFound();
            }

            var scheduleDTOs = new ScheduleDTO
            {
                ScheduleID = schedule.ScheduleID,
                TravelID = schedule.TravelID,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime
            };

            return scheduleDTOs;
        }


        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(int id, ScheduleDTO scheduleDTO)
        {
            if (id != scheduleDTO.ScheduleID)
            {
                return BadRequest();
            }

            var schedule = new Schedule
            {
                ScheduleID = scheduleDTO.ScheduleID,
                TravelID = scheduleDTO.TravelID,
                DepartureTime = scheduleDTO.DepartureTime,
                ArrivalTime = scheduleDTO.ArrivalTime
            };

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleDTO>> PostSchedule(ScheduleDTO scheduleDTO)
        {
            if (_context.Schedule == null)
            {
                return Problem("Entity set 'TravelContext.Schedule'  is null.");
            }

            var schedule = new Schedule
            {
                // Map properties from DTO to Schedule
                TravelID = scheduleDTO.TravelID,
                DepartureTime = scheduleDTO.DepartureTime,
                ArrivalTime = scheduleDTO.ArrivalTime
            };

            _context.Schedule.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = schedule.ScheduleID }, scheduleDTO);

        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            if (_context.Schedule == null)
            {
                return NotFound();
            }
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(int id)
        {
            return (_context.Schedule?.Any(e => e.ScheduleID == id)).GetValueOrDefault();
        }
    }
}
