using Microsoft.EntityFrameworkCore;

namespace Sinqia.Challenge.Infrastructure.Contexts.Persistence;

public static class AttractionDbContextFactory
{
	public static AttractionDbContext Create(string connectionString)
	{
		var optionsBuilder = new DbContextOptionsBuilder<AttractionDbContext>();
		optionsBuilder.UseSqlServer(connectionString);
		var attractionDbContext = new AttractionDbContext(optionsBuilder.Options);
		attractionDbContext.Database.EnsureCreated();
		return attractionDbContext;
	}
}