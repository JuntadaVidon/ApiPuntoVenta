namespace M4Facturation.Application.Validators
{
    public class ProductValidator : AbstractValidator<ProductPostUpdate>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("El campo producto es requerido");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("La categoria es requerida");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("El proveedor es requerido");
        }
    }
}