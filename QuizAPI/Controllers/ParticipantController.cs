#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;
using QuizAPI.RabitMQ;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;
        private readonly IParticipantServices _participantServices;
		public ParticipantController(QuizAPI.Models.QuizDbContext context, IRabitMQProducer rabitMQProducer , IParticipantServices participantServices)
        {
            _context = context;
            _rabitMQProducer = rabitMQProducer;
            _participantServices = participantServices;
        }

		// GET: api/Participant
		[HttpGet]
		public ActionResult<IEnumerable<Participant>> GetParticipants()
		{
			var list = new List<Participant>();
			var listAll = _participantServices.GetAll();
			if (listAll.Any())
			{
				foreach (var participant in listAll)
				{
					Participant participant1 = new Participant()
					{
						Email = participant.Email,
						Name = participant.Name,
						ParticipantId = participant.ParticipantId,
						Score = participant.Score,
						TimeTaken = participant.TimeTaken,
					};
					list.Add(participant1);
				}
			}
			return list;
		}

		// GET: api/Participant/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // PUT: api/Participant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, ParticipantRestult _participantResult)
        {
            if (id != _participantResult.ParticipantId)
            {
                return BadRequest();
            }

            // get all current details of the record, then update with quiz results
            Participant participant = _context.Participants.Find(id);
            participant.Score = _participantResult.Score;
            participant.TimeTaken = _participantResult.TimeTaken;
            // send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendParticipantMessage(participant);

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            var temp = _context.Participants
                .Where(x => x.Name == participant.Name
                && x.Email == participant.Email)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();
            }
            else
                participant = temp;

            return Ok(participant);
        }

        // DELETE: api/Participant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.ParticipantId == id);
        }
    }
}
