namespace Sinqia.Challenge.Domain.DTOs.Responses;

public class ResponseException(List<string> mensagem)
{
	public List<string> Mensagens { get; set; } = mensagem;
}