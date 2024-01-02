using FluentAssertions;
using Sinqia.Challenge.Application.UseCases;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.UnitTest.Utils.Builders;
using Sinqia.Challenge.UnitTest.Utils.Repositories;
using Xunit;

namespace Sinqia.Challenge.UnitTest.UseCases;

public class UpdateAttractionUnitTest
{
	private readonly AttractionRepositoryUnitTest _attractionRepository;
	private readonly AttractionUseCase _attractionUseCase;

	public UpdateAttractionUnitTest()
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
	public async Task ShouldSuccess()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().Build();

		var result = await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task ShouldBadRequest()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().BuildInvalid();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithNameEmpyt()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().WithFieldEmpty(c => c.Name).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithDescriptionEmpyt()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().WithFieldEmpty(c => c.Description).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithCityEmpyt()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().WithFieldEmpty(c => c.City).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithLocationEmpyt()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().WithFieldEmpty(c => c.Location).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithStateEmpyt()
	{
		var attractionId = await CreateAttractionAndGetId();
		var requestUpdate = new AttractionBuilder().WithFieldEmpty(c => c.State).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, attractionId);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithAttractionIdInvalid()
	{
		var requestUpdate = new AttractionBuilder().Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, Guid.NewGuid());
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

	[Fact]
	public async Task ShouldBadRequestWithNameExist()
	{
		var firstAttractionId = await CreateAttractionAndGetId();

		var secondRequestCreated = new AttractionBuilder().Build();
		await _attractionUseCase.CreateAttractionAsync(secondRequestCreated);

		var allAttractions = await _attractionRepository.FindAllAsync();
		var secondCreatedAttraction = allAttractions.OrderByDescending(a => a.CreatedAt).First();

		var requestUpdate = new AttractionBuilder().WithFieldExists(c => c.Name, secondCreatedAttraction.Name).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.UpdateAttractionAsync(requestUpdate, firstAttractionId);
		});
	}
}