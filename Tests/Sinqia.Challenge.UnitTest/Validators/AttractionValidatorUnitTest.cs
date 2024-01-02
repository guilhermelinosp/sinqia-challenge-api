using Sinqia.Challenge.UnitTest.Utils.Builders;
using Xunit;
using FluentAssertions;
using Sinqia.Challenge.Application.UseCases.Validators;

namespace Sinqia.Challenge.UnitTest.Validators;

public class AttractionValidatorTests
{
	[Fact]
	public async Task ShouldSucessRequest()
	{
		var request = new AttractionBuilder().Build();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeTrue();
	}

	[Fact]
	public async Task ShouldBadRequest()
	{
		var request = new AttractionBuilder().BuildInvalid();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeFalse();
	}

	[Fact]
	public async Task ShouldBadRequestNameEmpty()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.Name).Build();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeFalse();
	}

	[Fact]
	public async Task ShouldBadRequestDescriptionEmpty()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.Description).Build();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeFalse();
	}

	[Fact]
	public async Task ShouldBadRequestCityEmpty()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.City).Build();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeFalse();
	}

	[Fact]
	public async Task ShouldBadRequestLocationEmpty()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.Location).Build();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeFalse();
	}

	[Fact]
	public async Task ShouldBadRequestStateEmpty()
	{
		var request = new AttractionBuilder().WithFieldEmpty(c => c.State).Build();
		var result = await new AttractionValidator().ValidateAsync(request);

		result.IsValid.Should().BeFalse();
	}
}