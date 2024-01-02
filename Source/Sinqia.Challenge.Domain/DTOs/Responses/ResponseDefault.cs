namespace Sinqia.Challenge.Domain.DTOs.Responses;

public class ResponseDefault(string message)
{
	public string Message { get; set; } = message;
}