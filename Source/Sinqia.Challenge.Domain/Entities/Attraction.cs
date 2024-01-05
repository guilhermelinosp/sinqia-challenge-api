namespace Sinqia.Challenge.Domain.Entities;

public class Attraction
{
	public Guid AttractionId { get; set; } = Guid.NewGuid();

	public required string Name { get; set; }

	public required string Description { get; set; }

	public required string Location { get; set; }

	public required string City { get; set; }

	public required string State { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}