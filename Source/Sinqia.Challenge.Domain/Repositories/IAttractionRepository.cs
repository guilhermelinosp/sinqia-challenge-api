using Sinqia.Challenge.Domain.Entities;

namespace Sinqia.Challenge.Domain.Repositories;

public interface IAttractionRepository
{
	Task<IEnumerable<Attraction>> FindAllAttractionAsync();
	Task<Attraction?> FindByAttractionNameAsync(string name);
	Task<IEnumerable<Attraction>> SearchAttractionAsync(string search);
	Task CreateAttractionAsync(Attraction attraction);
}