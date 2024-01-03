using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.Domain.Repositories;

namespace Sinqia.Challenge.UnitTest.Utils.Repositories;

public interface IAttractionRepositoryUnitTest : IAttractionRepository;

public class AttractionRepositoryUnitTest : IAttractionRepositoryUnitTest
{
	private readonly List<Attraction> _attractions = [];

	public Task<IEnumerable<Attraction>> FindAllAttractionAsync()
	{
		return Task.FromResult<IEnumerable<Attraction>>(_attractions.ToList());
	}

	public Task<Attraction?> FindByAttractionNameAsync(string name)
	{
		return Task.FromResult(_attractions.Find(a => a.Name == name));
	}

	public async Task<IEnumerable<Attraction>> SearchAttractionAsync(string search)
	{
		return await Task.Run(() =>
			_attractions.Where(a =>
					a.Name.Contains(search) ||
					a.Description.Contains(search) ||
					a.Location.Contains(search))
				.ToList());
	}


	public Task CreateAttractionAsync(Attraction attraction)
	{
		_attractions.Add(attraction);
		return Task.CompletedTask;
	}
}