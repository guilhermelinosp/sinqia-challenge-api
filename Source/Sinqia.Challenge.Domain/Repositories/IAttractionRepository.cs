using Sinqia.Challenge.Domain.Entities;

namespace Sinqia.Challenge.Domain.Repositories;

public interface IAttractionRepository
{
	Task<IEnumerable<Attraction>> FindAllAsync();
	Task<Attraction?> FindByAttractionIdAsync(Guid id);
	Task<Attraction?> FindByAttractionNameAsync(string name);
	Task<Attraction?> FindByAttractionStateAsync(string state);
	Task<Attraction?> FindByAttractionCityAsync(string city);
	Task<Attraction?> FindByAttractionLocationAsync(string location);
	Task<IEnumerable<Attraction>> SearchAttractionByNameAsync(string search);
	Task<IEnumerable<Attraction>> SearchAttractionByDescriptionAsync(string search);
	Task<IEnumerable<Attraction>> SearchAttractionByLocationAsync(string search);
	Task CreateAttractionAsync(Attraction attraction);
	Task UpdateAttractionAsync(Attraction attraction);
	Task DeleteAttractionAsync(Attraction attraction);
}