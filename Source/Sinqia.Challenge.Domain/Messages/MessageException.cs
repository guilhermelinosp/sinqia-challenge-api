namespace Sinqia.Challenge.Domain.Messages;

public record MessageException
{
	public static string ATTRACTION_NOT_FOUND => "a atração não foi encontrada.";
	public static string NAME_ALREADY_EXISTS => "o nome da atração já existe.";
	public static string CITY_EMPYT => "a cidade da atração não pode ser vazio.";
	public static string CITY_MAX_LENGTH => "a cidade da atração não pode ter mais de 100 caracteres.";

	public static string STATE_EMPYT => "o estado da atração não pode ser vazio.";
	public static string STATE_MAX_LENGTH => "o estado da atração não pode ter mais de 2 caracteres.";
	public static string STATE_MIN_LENGTH => "o estado da atração não pode ter menos de 2 caracteres.";

	public static string NAME_EMPYT => "o nome da atração não pode ser vazio.";
	public static string NAME_MAX_LENGTH => "o nome da atração não pode ter mais de 100 caracteres.";

	public static string DESCRIPTION_EMPYT => "a descrição da atração não pode ser vazia.";
	public static string DESCRIPTION_MAX_LENGTH => "a descrição da atração não pode ter mais de 100 caracteres.";

	public static string LOCATION_EMPYT => "a localização da atração não pode ser vazia.";
	public static string LOCATION_MAX_LENGTH => "a localização da atração não pode ter mais de 100 caracteres.";


	public static string ERRO_DESCONHECIDO => "ocorreu um erro desconhecido.";
}