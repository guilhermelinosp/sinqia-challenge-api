using FluentAssertions;
using Sinqia.Challenge.Application.UseCases;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.UnitTest.Utils.Builders;
using Sinqia.Challenge.UnitTest.Utils.Repositories;
using Xunit;

namespace Sinqia.Challenge.UnitTest.UseCases;

public class GetAttractionByIdUnitTest
{
	private readonly AttractionRepositoryUnitTest _attractionRepository;
	private readonly AttractionUseCase _attractionUseCase;

	public GetAttractionByIdUnitTest()
	{
		_attractionRepository = new AttractionRepositoryUnitTest();
		_attractionUseCase = new AttractionUseCase(_attractionRepository);
	}

	private async Task<Guid> CreateAttractionAndGetId()
	{
		var requestCreated = new AttractionBuilder().Build();
		await _attractionUseCase.CreateAttractionAsync(requestCreated);

		var allAttractions = await _attractionRepository.FindAllAsync();
		var createdAttraction = allAttractions.OrderByDescending(a => a.CreatedAt).First();

		return createdAttraction.AttractionId;
	}

	[Fact]
	public async Task ShouldSuccessRequest()
	{
		var attractionId = await CreateAttractionAndGetId();
		var result = await _attractionUseCase.GetAttractionByIdAsync(attractionId);
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task ShouldBadRequestWithAttractionIdInvalid()
	{
		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.GetAttractionByIdAsync(Guid.NewGuid());
		});
	}

	[Fact]
	public async Task ShouldBadRequestBecauseAttractionIdIsEmpty()
	{
		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.GetAttractionByIdAsync(Guid.Empty);
		});
	}
}