using Sinqia.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Sinqia.Challenge.Infrastructure.Contexts.Configurations;

namespace Sinqia.Challenge.Infrastructure.Contexts;

public class AttractionDbContext(DbContextOptions<AttractionDbContext> options) : DbContext(options)
{
	public DbSet<Attraction>? Attractions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AttractionTypeConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}