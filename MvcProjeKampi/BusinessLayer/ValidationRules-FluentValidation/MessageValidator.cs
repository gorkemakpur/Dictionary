using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class MessageValidator :AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi Boş Olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Olamaz");

            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Mail Adresi Giriniz").When(i=>!string.IsNullOrEmpty(i.ReceiverMail));
            RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçerli Mail Adresi Giriniz").When(i=>!string.IsNullOrEmpty(i.SenderMail));


            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");
        }
    }
}
