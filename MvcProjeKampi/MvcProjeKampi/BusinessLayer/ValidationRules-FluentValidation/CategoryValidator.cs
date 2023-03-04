using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            //CategoryName Rules
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapın");

            //CategoryDescription Rules
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
        }
    }
}
