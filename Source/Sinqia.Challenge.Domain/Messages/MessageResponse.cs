namespace Sinqia.Challenge.Domain.Messages;

public record MessageResponse
{
	public static string ATTRACTION_CREATED => "a atração foi criada com sucesso.";

	public static string ATTRACTION_UPDATED => "a atração foi atualizada com sucesso.";

	public static string ATTRACTION_DELETED => "a atração foi deletada com sucesso.";
};