using Sinqia.Challenge.Application.UseCases.Validators;
using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;
using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.Domain.Messages;
using Sinqia.Challenge.Domain.Repositories;

namespace Sinqia.Challenge.Application.UseCases;

public class AttractionUseCase(IAttractionRepository repository) : IAttractionUseCase
{
	public async Task<IEnumerable<ResponseAttraction>> GetAllAttractionAsync()
	{
		var attractions = await repository.FindAllAsync();
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

	public async Task<ResponseAttraction> GetAttractionByIdAsync(Guid id)
	{
		var attraction = await repository.FindByAttractionIdAsync(id);
		if (attraction == null)
			throw new DefaultException([MessageException.ATTRACTION_NOT_FOUND]);

		return new ResponseAttraction
		{
			AttractionId = attraction.AttractionId,
			Name = attraction.Name,
			Description = attraction.Description,
			Location = attraction.Location,
			City = attraction.City,
			State = attraction.State,
			CreatedAt = attraction.CreatedAt,
			UpdatedAt = attraction.UpdatedAt
		};
	}

	public async Task<IEnumerable<ResponseAttraction>> SearchAttractionByNameAsync(string? search)
	{
		if (string.IsNullOrEmpty(search))
			return await GetAllAttractionAsync();

		var attractions = await repository.SearchAttractionByNameAsync(search);
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

	public async Task<IEnumerable<ResponseAttraction>> SearchAttractionByDescriptionAsync(string? search)
	{
		if (string.IsNullOrEmpty(search))
			return await GetAllAttractionAsync();

		var attractions = await repository.SearchAttractionByDescriptionAsync(search);
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

	public async Task<IEnumerable<ResponseAttraction>> SearchAttractionByLocationAsync(string? search)
	{
		if (string.IsNullOrEmpty(search))
			return await GetAllAttractionAsync();

		var attractions = await repository.SearchAttractionByLocationAsync(search);
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

		await repository.CreateAttractionAsync(new Attraction()
		{
			City = request.City,
			Description = request.Description,
			Location = request.Location,
			Name = request.Name,
			State = request.State
		});

		return new ResponseDefault(MessageResponse.ATTRACTION_CREATED);
	}

	public async Task<ResponseDefault> UpdateAttractionAsync(RequestAttraction request, Guid id)
	{
		var validatorRequest = await new AttractionValidator().ValidateAsync(request);
		if (!validatorRequest.IsValid)
			throw new DefaultException(validatorRequest.Errors.Select(er => er.ErrorMessage).ToList());

		var attraction = await repository.FindByAttractionIdAsync(id);
		if (attraction == null)
			throw new DefaultException([MessageException.ATTRACTION_NOT_FOUND]);

		if (request.Name != attraction.Name)
		{
			var attractionName = await repository.FindByAttractionNameAsync(request.Name);
			if (attractionName != null)
				throw new DefaultException([MessageException.NAME_ALREADY_EXISTS]);
		}

		attraction.City = request.City == attraction.City ? attraction.City : request.City;
		attraction.Description =
			request.Description == attraction.Description ? attraction.Description : request.Description;
		attraction.Location = request.Location == attraction.Location ? attraction.Location : request.Location;
		attraction.Name = request.Name == attraction.Name ? attraction.Name : request.Name;
		attraction.State = request.State == attraction.State ? attraction.State : request.State;
		attraction.UpdatedAt = DateTime.UtcNow;

		await repository.UpdateAttractionAsync(attraction);

		return new ResponseDefault(MessageResponse.ATTRACTION_UPDATED);
	}

	public async Task<ResponseDefault> DeleteAttractionAsync(Guid id)
	{
		var attraction = await repository.FindByAttractionIdAsync(id);
		if (attraction == null)
			throw new DefaultException([MessageException.ATTRACTION_NOT_FOUND]);


		await repository.DeleteAttractionAsync(attraction);
		return new ResponseDefault(MessageResponse.ATTRACTION_DELETED);
	}
}