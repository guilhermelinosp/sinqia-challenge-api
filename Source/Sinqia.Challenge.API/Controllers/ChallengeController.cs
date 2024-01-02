using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sinqia.Challenge.API.Controllers.Abstract;
using Sinqia.Challenge.Application.UseCases;
using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;

namespace Sinqia.Challenge.API.Controllers;

[ApiController]
[Route("api/v1/pontos-turisticos")]
[Produces("application/json")]
[ProducesResponseType<BaseActionResult<ResponseException>>(StatusCodes.Status400BadRequest)]
[ProducesResponseType<BaseActionResult<ResponseException>>(StatusCodes.Status500InternalServerError)]
[ProducesResponseType<BaseActionResult<ResponseDefault>>(StatusCodes.Status200OK)]
public class ChallengeController(IAttractionUseCase attraction) : Controller
{
	[HttpGet]
	[ProducesResponseType<BaseActionResult<IEnumerable<ResponseAttraction>>>(StatusCodes.Status200OK)]
	public async Task<BaseActionResult<IEnumerable<ResponseAttraction>>> GetAllAttractionAsync()
	{
		var response = await attraction.GetAllAttractionAsync();
		return new BaseActionResult<IEnumerable<ResponseAttraction>>(HttpStatusCode.OK, response);
	}

	[HttpGet("{id}")]
	public async Task<BaseActionResult<ResponseAttraction>> GetAttractionByIdAsync(Guid id)
	{
		var response = await attraction.GetAttractionByIdAsync(id);
		return new BaseActionResult<ResponseAttraction>(HttpStatusCode.OK, response);
	}

	[HttpGet("search-name")]
	public async Task<BaseActionResult<IEnumerable<ResponseAttraction>>> SearchAttractionByNameAsync(
		[FromQuery] string search)
	{
		var response = await attraction.SearchAttractionByNameAsync(search);
		return new BaseActionResult<IEnumerable<ResponseAttraction>>(HttpStatusCode.OK, response);
	}

	[HttpGet("search-location")]
	public async Task<BaseActionResult<IEnumerable<ResponseAttraction>>> SearchAttractionByLocationAsync(
		[FromQuery] string search)
	{
		var response = await attraction.SearchAttractionByLocationAsync(search);
		return new BaseActionResult<IEnumerable<ResponseAttraction>>(HttpStatusCode.OK, response);
	}

	[HttpGet("search-description")]
	public async Task<BaseActionResult<IEnumerable<ResponseAttraction>>> SearchAttractionByDescriptionAsync(
		[FromQuery] string search)
	{
		var response = await attraction.SearchAttractionByDescriptionAsync(search);
		return new BaseActionResult<IEnumerable<ResponseAttraction>>(HttpStatusCode.OK, response);
	}

	[HttpPost]
	public async Task<BaseActionResult<ResponseDefault>> CreateAttractionAsync([FromBody] RequestAttraction request)
	{
		var response = await attraction.CreateAttractionAsync(request);
		return new BaseActionResult<ResponseDefault>(HttpStatusCode.OK, response);
	}

	[HttpPut("{id}")]
	public async Task<BaseActionResult<ResponseDefault>> UpdateAttractionAsync([FromBody] RequestAttraction request,
		Guid id)
	{
		var response = await attraction.UpdateAttractionAsync(request, id);
		return new BaseActionResult<ResponseDefault>(HttpStatusCode.OK, response);
	}

	[HttpDelete("{id}")]
	public async Task<BaseActionResult<ResponseDefault>> DeleteAttractionAsync(Guid id)
	{
		var response = await attraction.DeleteAttractionAsync(id);
		return new BaseActionResult<ResponseDefault>(HttpStatusCode.OK, response);
	}
}