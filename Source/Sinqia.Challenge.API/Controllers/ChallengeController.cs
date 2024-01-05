using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sinqia.Challenge.Application.UseCases;
using Sinqia.Challenge.API.Controllers.Abstract;
using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;

namespace Sinqia.Challenge.API.Controllers;

[ApiController]
[Route("api/v1/pontos-turisticos")]
[Produces("application/json")]
[ProducesResponseType<BaseActionResult<ResponseException>>(StatusCodes.Status400BadRequest)]
[ProducesResponseType<BaseActionResult<ResponseException>>(StatusCodes.Status500InternalServerError)]
public class ChallengeController(IAttractionUseCase attraction) : Controller
{
	[HttpPost]
	public async Task<BaseActionResult<ResponseDefault>> CreateAttractionAsync([FromBody] RequestAttraction request)
	{
		var response = await attraction.CreateAttractionAsync(request);
		return new BaseActionResult<ResponseDefault>(HttpStatusCode.OK, response);
	}

	[HttpGet]
	[ProducesResponseType<BaseActionResult<IEnumerable<ResponseAttraction>>>(StatusCodes.Status200OK)]
	public async Task<BaseActionResult<IEnumerable<ResponseAttraction>>> SearchAttractionAsync(
		[FromQuery] string? search)
	{
		var response = await attraction.SearchAttractionAsync(search!);
		return new BaseActionResult<IEnumerable<ResponseAttraction>>(HttpStatusCode.OK, response);
	}
}