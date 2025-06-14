using BlogStore.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        // new'leme ihtiyacı olmadan çalışması için constructorla çalışır. Bu sınıf çağırıldığı anda direkt olarak metotları devreye girecek.
        public CategoryValidator()
        {
            RuleFor(x =>x.CategoryName).NotEmpty().WithMessage("Lütfen kategori adını giriniz");
            RuleFor(x => x.CategoryName)
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız!")
                .MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız!"); 
        }
    }
}
