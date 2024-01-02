using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Repositories;

namespace Sinqia.Challenge.UnitTest.Utils.Repositories;

public interface IAttractionRepositoryUnitTest : IAttractionRepository
{
	new Task<IEnumerable<Attraction>> FindAllAsync();
	new Task<Attraction?> FindByAttractionIdAsync(Guid id);
	new Task<Attraction?> FindByAttractionNameAsync(string name);
	new Task<Attraction?> FindByAttractionStateAsync(string state);
	new Task<Attraction?> FindByAttractionCityAsync(string city);
	new Task<Attraction?> FindByAttractionLocationAsync(string location);
	new Task<IEnumerable<Attraction>> SearchAttractionByNameAsync(string search);
	new Task<IEnumerable<Attraction>> SearchAttractionByDescriptionAsync(string search);
	new Task<IEnumerable<Attraction>> SearchAttractionByLocationAsync(string search);
	new Task CreateAsync(Attraction attraction);
	new Task UpdateAsync(Attraction attraction);
	new Task DeleteAsync(Attraction attraction);
}