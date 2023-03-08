﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        //Contact Rules
        public ContactValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Mail Adresi Boş Olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapın");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girişi Yapın");
        }
    }


}
