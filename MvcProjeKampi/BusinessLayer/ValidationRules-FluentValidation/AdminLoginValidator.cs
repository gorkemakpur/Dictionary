using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class AdminLoginValidator :AbstractValidator<Admin>
    {
        public AdminLoginValidator()
        {
            
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre Adı Boş Olamaz");

          
        }
    }
}
