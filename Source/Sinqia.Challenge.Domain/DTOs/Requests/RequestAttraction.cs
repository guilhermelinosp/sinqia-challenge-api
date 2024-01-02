namespace Sinqia.Challenge.Domain.DTOs.Requests;

public class RequestAttraction
{
	public required string Name { get; set; }
	public required string State { get; set; }
	public required string City { get; set; }
	public required string Location { get; set; }
	public required string Description { get; set; }
}