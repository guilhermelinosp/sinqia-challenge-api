using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Exceptions;

namespace Sinqia.Challenge.UnitTest.Utils.Repositories;

public class AttractionRepositoryUnitTest : IAttractionRepositoryUnitTest
{
	private readonly List<Attraction> _attractions = [];

	public Task<IEnumerable<Attraction>> FindAllAsync()
	{
		return Task.FromResult<IEnumerable<Attraction>>(_attractions.ToList());
	}

	public Task<Attraction?> FindByAttractionIdAsync(Guid id)
	{
		return Task.FromResult(_attractions!.FirstOrDefault(a => a.AttractionId == id));
	}

	public Task<Attraction?> FindByAttractionNameAsync(string name)
	{
		return Task.FromResult(_attractions.FirstOrDefault(a => a.Name == name));
	}

	public Task<Attraction?> FindByAttractionStateAsync(string state)
	{
		return Task.FromResult(_attractions.FirstOrDefault(a => a.State == state));
	}

	public Task<Attraction?> FindByAttractionCityAsync(string city)
	{
		return Task.FromResult(_attractions.FirstOrDefault(a => a.City == city));
	}

	public Task<Attraction?> FindByAttractionLocationAsync(string location)
	{
		return Task.FromResult(_attractions.FirstOrDefault(a => a.Location == location));
	}

	public Task<IEnumerable<Attraction>> SearchAttractionByNameAsync(string search)
	{
		return Task.FromResult<IEnumerable<Attraction>>(_attractions.Where(a => a.Name.Contains(search)).ToList());
	}

	public Task<IEnumerable<Attraction>> SearchAttractionByDescriptionAsync(string search)
	{
		return Task.FromResult<IEnumerable<Attraction>>(
			_attractions.Where(a => a.Description.Contains(search)).ToList());
	}

	public Task<IEnumerable<Attraction>> SearchAttractionByLocationAsync(string search)
	{
		return Task.FromResult<IEnumerable<Attraction>>(_attractions.Where(a => a.Location.Contains(search)).ToList());
	}

	public async Task CreateAsync(Attraction attraction)
	{
		throw new NotImplementedException();
	}

	public async Task UpdateAsync(Attraction attraction)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteAsync(Attraction attraction)
	{
		throw new NotImplementedException();
	}

	public Task CreateAttractionAsync(Attraction attraction)
	{
		_attractions.Add(attraction);
		return Task.CompletedTask;
	}

	public Task UpdateAttractionAsync(Attraction attraction)
	{
		var existingAttraction = _attractions.FirstOrDefault(a => a.AttractionId == attraction.AttractionId);
		if (existingAttraction == null) return Task.CompletedTask;

		existingAttraction.Name = attraction.Name;
		existingAttraction.Description = attraction.Description;
		existingAttraction.Location = attraction.Location;
		existingAttraction.City = attraction.City;
		existingAttraction.State = attraction.State;

		return Task.CompletedTask;
	}

	public async Task DeleteAttractionAsync(Attraction attraction)
	{
		_attractions.Remove(attraction);
		await Task.CompletedTask;
	}
}