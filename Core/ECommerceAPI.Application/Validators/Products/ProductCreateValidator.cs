using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class ProductCreateValidator:AbstractValidator<ProductCreateViewModel>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen 2 ile 150 karakter arasında ürün ismi giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen stok miktarını boş geçmeyiniz.")
                .Must(s => s >= 0)
                .WithMessage("Stok bilgisi negatif olamaz.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün fiyatını boş geçmeyiniz.")
                .Must(p => p >= 0)
                .WithMessage("Ürün fiyatı negatif olamaz.");
        }
    }
}
