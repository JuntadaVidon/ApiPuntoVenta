namespace M4Facturation.Application.Validators
{
    public class ExampleValidator : AbstractValidator<ExampleDtoFile>
    {
        public ExampleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El campo Name es requerido.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("El campo Id es requerido.");
        }
    }
}
