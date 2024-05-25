using FluentValidation;

namespace Assets.Application.Materials.Commands.UpdateCommand
{
    public class UpdateMaterialCommandValidator: AbstractValidator<UpdateMaterialCommand>   
    {
        private readonly List<string> validCategories = ["wood", "steel", "iron", "hollowBlock", "CeramicBlock"];
        public UpdateMaterialCommandValidator() {

            RuleFor(dto => dto.Name)
               .Must(validCategories.Contains)
               .WithMessage($"Invalid category. Please choose from the valid categories: {string.Join(", ", validCategories)}");

            RuleFor(dto => dto.Price)
              .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
