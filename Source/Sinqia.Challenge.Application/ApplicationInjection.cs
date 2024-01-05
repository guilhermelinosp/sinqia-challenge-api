using Sinqia.Challenge.Infrastructure;
using Sinqia.Challenge.Application.UseCases;

namespace Sinqia.Challenge.Application;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationInjection
{
	public static void AddApplicationInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddInfrastructureInjection(configuration);
		services.AddUseCases();
	}

	private static void AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<IAttractionUseCase, AttractionUseCase>();
	}
}