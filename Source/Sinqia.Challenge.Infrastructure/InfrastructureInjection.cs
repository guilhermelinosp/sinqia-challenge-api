using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinqia.Challenge.Domain.Repositories;
using Sinqia.Challenge.Infrastructure.Contexts;
using Sinqia.Challenge.Infrastructure.Repositories;

namespace Sinqia.Challenge.Infrastructure;

public static class InfrastructureInjection
{
	public static void AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContexts(configuration);
		services.AddRepositories();
	}

	private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AttractionDbContext>(options =>
			options.UseSqlServer(configuration["SQLServer:ConnectionString"],
				sqlServerOptions => { sqlServerOptions.EnableRetryOnFailure(); }));
	}

	private static void AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IAttractionRepository, AttractionRepository>();
	}
}