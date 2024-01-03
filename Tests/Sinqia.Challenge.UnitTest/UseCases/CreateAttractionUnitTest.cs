using FluentAssertions;
using Sinqia.Challenge.Application.UseCases;
using Sinqia.Challenge.Domain.Exceptions;
using Sinqia.Challenge.UnitTest.Utils.Builders;
using Sinqia.Challenge.UnitTest.Utils.Repositories;
using Xunit;

namespace Sinqia.Challenge.UnitTest.UseCases;

public class CreateAttractionUnitTest
{
	private readonly AttractionUseCase _attractionUseCase;

	public CreateAttractionUnitTest()
	{
		var attractionRepository = new AttractionRepositoryUnitTest();
		_attractionUseCase = new AttractionUseCase(attractionRepository);
	}

	[Fact]
	public async Task ShouldSuccessRequest()
	{
		var request = new AttractionBuilder().Build();

		var result = await _attractionUseCase.CreateAttractionAsync(request);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task ShouldBadRequest()
	{
		var request = new AttractionBuilder().BuildInvalid();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(request);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithNameEmpyt()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.Name).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(request);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithDescriptionEmpyt()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.Description).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(request);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithCityEmpyt()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.City).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(request);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithLocationEmpyt()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.Location).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(request);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithStateEmpyt()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.State).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(request);
		});
	}

	[Fact]
	public async Task ShouldBadRequestWithNameExist()
	{
		var request = new AttractionBuilder().Build();
		await _attractionUseCase.CreateAttractionAsync(request);

		var newRequest = new AttractionBuilder().WithFieldExists(c => c.Name, request.Name).Build();

		await Assert.ThrowsAsync<DefaultException>(async () =>
		{
			await _attractionUseCase.CreateAttractionAsync(newRequest);
		});
	}
	
	
}