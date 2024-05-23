using FluentValidation;

namespace Assets.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialValidator: AbstractValidator<CreateMaterialCommand>
    {
       public CreateMaterialValidator() {
            RuleFor(material => material.Price).GreaterThanOrEqualTo(0)
                 .WithMessage("Price must be a non-negative number.");
        }
    }
}
