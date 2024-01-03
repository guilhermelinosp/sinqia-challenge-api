using System.Linq.Expressions;
using Bogus;
using Sinqia.Challenge.Domain.DTOs.Requests;

namespace Sinqia.Challenge.UnitTest.Utils.Builders;

public class AttractionBuilder
{
	private const string EmptyString = "";
	private readonly Faker<RequestAttraction> _builder;

	public AttractionBuilder()
	{
		_builder = new Faker<RequestAttraction>()
			.RuleFor(c => c.Name, f => f.Name.FirstName())
			.RuleFor(c => c.Description, f => f.Lorem.Sentence())
			.RuleFor(c => c.Location, f => f.Address.StreetName())
			.RuleFor(c => c.City, f => f.Address.City())
			.RuleFor(c => c.State, f => f.Address.StateAbbr());
	}

	public RequestAttraction Build()
	{
		return _builder.Generate();
	}

	public RequestAttraction BuildInvalid()
	{
		return InvalidatedBuilder().Generate();
	}

	private Faker<RequestAttraction> InvalidatedBuilder()
	{
		return new Faker<RequestAttraction>()
			.RuleFor(c => c.Name, f => EmptyString)
			.RuleFor(c => c.Description, f => null!)
			.RuleFor(c => c.Location, f => f.Lorem.Sentence())
			.RuleFor(c => c.City, f => "CityName")
			.RuleFor(c => c.State, f => f.PickRandom(null, EmptyString));
	}

	public AttractionBuilder WithFieldEmpty<TProperty>(Expression<Func<RequestAttraction, TProperty>> property)
	{
		if (typeof(TProperty) == typeof(string)) _builder.RuleFor(property, f => (TProperty)(object)string.Empty);

		return this;
	}

	public AttractionBuilder WithFieldExists<TProperty>(Expression<Func<RequestAttraction, TProperty>> property,
		TProperty value)
	{
		if (typeof(TProperty) == typeof(string)) _builder.RuleFor(property, f => value);

		return this;
	}
}