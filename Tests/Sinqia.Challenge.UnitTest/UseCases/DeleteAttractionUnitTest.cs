using FluentAssertions;
using Sinqia.Challenge.Application.UseCases;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.UnitTest.Utils.Builders;
using Sinqia.Challenge.UnitTest.Utils.Repositories;
using Xunit;

namespace Sinqia.Challenge.UnitTest.UseCases;

public class DeleteAttractionUnitTest
{
	private readonly AttractionRepositoryUnitTest _attractionRepository;
	private readonly AttractionUseCase _attractionUseCase;

	public DeleteAttractionUnitTest()
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
		await _attractionUseCase.DeleteAttractionAsync(attractionId);
		var result = await _attractionRepository.FindByAttractionIdAsync(attractionId);
		result.Should().BeNull();
	}

	[Fact]
	public async Task ShouldBadRequestWithAttractionIdInvalid()
	{
		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.DeleteAttractionAsync(Guid.NewGuid());
		});
	}

	[Fact]
	public async Task ShouldBadRequestBecauseAttractionIdIsEmpty()
	{
		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.DeleteAttractionAsync(Guid.Empty);
		});
	}
}