using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinqia.Challenge.Domain.Entities;

namespace Sinqia.Challenge.Infrastructure.Contexts.Configurations;

public class AttractionTypeConfiguration : IEntityTypeConfiguration<Attraction>
{
	public void Configure(EntityTypeBuilder<Attraction> builder)
	{
		builder.ToTable("TB_Attractions");

		builder.HasKey(attraction => attraction.AttractionId);

		builder.Property(attraction => attraction.AttractionId)
			.ValueGeneratedOnAdd();

		builder.Property(attraction => attraction.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(attraction => attraction.Description)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(attraction => attraction.Location)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(attraction => attraction.City)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(attraction => attraction.State)
			.IsRequired()
			.HasMaxLength(2);

		builder.Property(attraction => attraction.CreatedAt)
			.ValueGeneratedOnAdd();

		builder.Property(attraction => attraction.UpdatedAt)
			.ValueGeneratedOnAdd();
	}
}