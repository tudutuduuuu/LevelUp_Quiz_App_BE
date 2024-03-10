using Entity.Models;
using Interface;

namespace Repository
{
	public class ParticipantRepository : IParticipantRepository
	{
		private readonly QuizDBContext _context;
        public ParticipantRepository(QuizDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Participant> GetParticipants()
		{
			return _context.Participants.ToList();
		}
	}
}