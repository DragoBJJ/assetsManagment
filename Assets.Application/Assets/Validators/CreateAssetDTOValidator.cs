
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Assets.Application.Assets.DTO;
using Assets.Domain;
using FluentValidation;

namespace Assets.Application.Assets.Validators;

public class CreateAssetDTOValidator: AbstractValidator<CreateAssetDTO>
{

    private readonly List<string> validCategories = ["House", "Apartament", "Office", "Store"];
    public CreateAssetDTOValidator() {

        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage($"Invalid category. Please choose from the valid categories: {string.Join(", ", validCategories)}");

        RuleFor(dto => dto.Category)
       .NotEmpty().WithMessage("Category is required.");

        RuleFor(dto => dto.Description)
       .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Space)
        .NotEmpty().WithMessage("Insert a valid space in meters");


        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");
    }  
    }

