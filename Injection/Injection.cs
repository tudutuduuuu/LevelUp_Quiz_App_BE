using Entity.Models;
using Interface;
using Interface.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace Injection
{
	public class Injection
	{
		public static void Inject(IServiceCollection service)
		{
			service.AddDbContext<QuizDBContext>(options =>
		options.UseSqlServer("Server=.;Database=QuizDB;Trusted_Connection=True;MultipleActiveResultSets=True;User ID=sa;Password=Iloveyou1234;"));
			service.AddTransient<IParticipantRepository, ParticipantRepository>();
			service.AddTransient<IParticipantServices, ParticipantServices>();
		}
	}
}