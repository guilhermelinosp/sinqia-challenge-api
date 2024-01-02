using Sinqia.Challenge.Domain.Entities;

namespace Sinqia.Challenge.Infrastructure.Contexts.Persistence;

public static class AttractionDbContextExtensions
{
	public static void Seed(this AttractionDbContext attractionDbContext)
	{
		if (attractionDbContext.Attractions!.Any()) return;

		attractionDbContext.Attractions!.AddRange(new List<Attraction>
		{
			new()
			{
				Name = "Cristo Redentor",
				Description = "Descrição para o Cristo Redentor.",
				Location = "Parque Nacional da Tijuca",
				City = "Rio de Janeiro",
				State = "RJ"
			},
			new()
			{
				Name = "Pão de Açúcar",
				Description = "Descrição para o Pão de Açúcar.",
				Location = "Morro da Urca",
				City = "Rio de Janeiro",
				State = "RJ"
			},
			new()
			{
				Name = "Catedral Metropolitana de São Sebastião do Rio de Janeiro",
				Description = "Descrição para o Catedral Metropolitana de São Sebastião do Rio de Janeiro.",
				Location = "Av. Chile, 245 - Centro",
				City = "Rio de Janeiro",
				State = "RJ"
			},
			new()
			{
				Name = "Museu do Amanhã",
				Description = "Descrição para o Museu do Amanhã.",
				Location = "Praça Mauá, 1 - Centro",
				City = "Rio de Janeiro",
				State = "RJ"
			}
		});

		attractionDbContext.SaveChanges();
	}
}