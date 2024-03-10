using AutoMapper;
using DTO.Model;
using Entity.Models;

namespace AutoMapperConfig
{
	public class AutoMapperConfig
	{
		public static Mapper InitializeAutomapper()
		{
			//Provide all the Mapping Configuration
			var config = new MapperConfiguration(cfg =>
			{
				//Configuring Employee and EmployeeDTO
				cfg.CreateMap<ParticipantServiceDto, Participant>();
				cfg.CreateMap<Participant, ParticipantServiceDto>();
				//Any Other Mapping Configuration ....
			});

			//Create an Instance of Mapper and return that Instance
			var mapper = new Mapper(config);
			return mapper;
		}
	}
}