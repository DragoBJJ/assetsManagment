using FluentValidation;

namespace Assets.Application.Assets.Commands.UpdateAsset
{
    public class UpdateAssetCommandValidator: AbstractValidator<UpdateAssetCommand>
    {
       
        public UpdateAssetCommandValidator()
        {

            RuleFor(dto => dto.Name)
                .Length(3, 100);
        }
    }

}
