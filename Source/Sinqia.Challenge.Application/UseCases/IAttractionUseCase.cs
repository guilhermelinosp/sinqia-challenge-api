using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;

namespace Sinqia.Challenge.Application.UseCases;

public interface IAttractionUseCase
{
	Task<IEnumerable<ResponseAttraction>> SearchAttractionAsync(string? search);
	Task<ResponseDefault> CreateAttractionAsync(RequestAttraction request);
}