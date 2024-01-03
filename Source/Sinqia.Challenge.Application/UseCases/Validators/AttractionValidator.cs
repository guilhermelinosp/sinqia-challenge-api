using FluentValidation;
using Sinqia.Challenge.Domain.DTOs.Requests;
using Sinqia.Challenge.Domain.DTOs.Responses;
using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Exceptions;

namespace Sinqia.Challenge.Application.UseCases.Validators;

public class AttractionValidator : AbstractValidator<RequestAttraction>
{
	public AttractionValidator()
	{
		RuleFor(attraction => attraction.Name)
			.NotEmpty()
			.WithMessage(MessageException.NAME_EMPYT)
			.MaximumLength(100)
			.WithMessage(MessageException.NAME_MAX_LENGTH);

		RuleFor(attraction => attraction.Description)
			.NotEmpty()
			.WithMessage(MessageException.DESCRIPTION_EMPYT)
			.MaximumLength(100)
			.WithMessage(MessageException.DESCRIPTION_MAX_LENGTH);

		RuleFor(attraction => attraction.Location)
			.NotEmpty()
			.WithMessage(MessageException.LOCATION_EMPYT)
			.MaximumLength(100)
			.WithMessage(MessageException.LOCATION_MAX_LENGTH);

		RuleFor(attraction => attraction.City)
			.NotEmpty()
			.WithMessage(MessageException.CITY_EMPYT)
			.MaximumLength(100)
			.WithMessage(MessageException.CITY_MAX_LENGTH);

		RuleFor(attraction => attraction.State)
			.NotEmpty()
			.WithMessage(MessageException.STATE_EMPYT)
			.MaximumLength(2)
			.WithMessage(MessageException.STATE_MAX_LENGTH)
			.MinimumLength(2)
			.WithMessage(MessageException.STATE_MIN_LENGTH);
	}
}