using AutoMapperConfig;
using DTO.Model;
using Entity.Models;
using Interface;
using Interface.Services;

namespace Services
{
	public class ParticipantServices : IParticipantServices
	{
		private readonly IParticipantRepository _participantRepository;
		public ParticipantServices(IParticipantRepository participantRepository)
		{
			_participantRepository = participantRepository;
		}
		public IEnumerable<ParticipantServiceDto> GetAll()
		{
			var result = new List<ParticipantServiceDto>();
			var listAll = _participantRepository.GetParticipants();
			if (listAll.Any())
			{
				foreach (var item in listAll)
				{
					var mapper = AutoMapperConfig.AutoMapperConfig.InitializeAutomapper();
					var employeeServiceDto = mapper.Map<Participant, ParticipantServiceDto>(item);

					result.Add(employeeServiceDto);
				}
			}
			return result;
		}
	}
}