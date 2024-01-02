using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;

namespace Sinqia.Challenge.Application.UseCases;

public interface IAttractionUseCase
{
	Task<IEnumerable<ResponseAttraction>> GetAllAttractionAsync();
	Task<ResponseAttraction> GetAttractionByIdAsync(Guid id);
	Task<IEnumerable<ResponseAttraction>> SearchAttractionByNameAsync(string? search);
	Task<IEnumerable<ResponseAttraction>> SearchAttractionByDescriptionAsync(string? search);
	Task<IEnumerable<ResponseAttraction>> SearchAttractionByLocationAsync(string? search);
	Task<ResponseDefault> CreateAttractionAsync(RequestAttraction request);
	Task<ResponseDefault> UpdateAttractionAsync(RequestAttraction request, Guid id);
	Task<ResponseDefault> DeleteAttractionAsync(Guid id);
}