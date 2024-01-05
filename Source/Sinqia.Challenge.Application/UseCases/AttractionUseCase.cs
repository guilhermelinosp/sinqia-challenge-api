using Sinqia.Challenge.Application.UseCases.Validators;
using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;
using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.Domain.Repositories;

namespace Sinqia.Challenge.Application.UseCases;

public class AttractionUseCase(IAttractionRepository repository) : IAttractionUseCase
{
	public async Task<IEnumerable<ResponseAttraction>> SearchAttractionAsync(string? search)
	{
		var attractions = string.IsNullOrEmpty(search)
			? await repository.FindAllAttractionAsync()
			: await repository.SearchAttractionAsync(search);
		return attractions.Select(attraction => new ResponseAttraction
		{
			AttractionId = attraction.AttractionId,
			Name = attraction.Name,
			Description = attraction.Description,
			Location = attraction.Location,
			City = attraction.City,
			State = attraction.State,
			CreatedAt = attraction.CreatedAt,
			UpdatedAt = attraction.UpdatedAt
		});
	}

	public async Task<ResponseDefault> CreateAttractionAsync(RequestAttraction request)
	{
		var validatorRequest = await new AttractionValidator().ValidateAsync(request);
		if (!validatorRequest.IsValid)
			throw new DefaultException(validatorRequest.Errors.Select(er => er.ErrorMessage).ToList());

		if (await repository.FindByAttractionNameAsync(request.Name) != null)
			throw new DefaultException([MessageException.NAME_ALREADY_EXISTS]);

		await repository.CreateAttractionAsync(new Attraction
		{
			City = request.City,
			Description = request.Description,
			Location = request.Location,
			Name = request.Name,
			State = request.State
		});

		return new ResponseDefault("Atração criada com sucesso!");
	}
}