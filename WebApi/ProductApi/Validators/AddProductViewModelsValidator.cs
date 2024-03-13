using FluentValidation;
using ProductApi.ViewModels;

namespace ProductApi.Validators
{
    public class AddProductViewModelsValidator:AbstractValidator<AddProductViewModel>
    {
        public AddProductViewModelsValidator() 
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .NotNull()
                .Length(5, 25);

        }
    }
}
