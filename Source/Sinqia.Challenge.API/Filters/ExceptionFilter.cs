using System.Net;
using Sinqia.Challenge.Domain.DTOs.Responses;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sinqia.Challenge.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		Console.WriteLine(context.Exception);

		if (context.Exception is DefaultException exception)
			context.Result = new ObjectResult(new { data = new ResponseException(exception.ErrorMessages!.ToList()) })
			{
				StatusCode = (int)HttpStatusCode.BadRequest
			};
		else
			context.Result =
				new ObjectResult(new { data = new ResponseException([MessageException.ERRO_DESCONHECIDO]) })
				{
					StatusCode = (int)HttpStatusCode.InternalServerError
				};
	}
}