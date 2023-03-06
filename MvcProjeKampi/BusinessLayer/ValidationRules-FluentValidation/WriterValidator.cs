using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            //WriterName Rules
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapın");

            //WriterSurname
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapın");

            //WriterAbout Rules
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).Must(IsAboutHasA).WithMessage("Hakkımda kısmında bir adet 'A-a' harfi olmak zorunda");

            //WriterAbout Rules
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Hakkımda kısmını Boş Geçemezsiniz");

        }
        private bool IsAboutHasA(string arg)// hakkımda yazısı içinde a harfi olmak zorunda
        {
            Regex regex = new Regex(@"a");
            return regex.IsMatch(arg);
        }
    }
}
