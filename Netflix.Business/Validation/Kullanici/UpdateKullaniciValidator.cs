using FluentValidation;
using Netflix.DAL.Dto.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.Kullanici
{
   public class UpdateKullaniciValidator : AbstractValidator<UpdateKullaniciDto>
    {
        public UpdateKullaniciValidator()
        {
            RuleFor(p => p.Mail).NotEmpty().WithMessage("Mail boş geçilemez.").MaximumLength(100).WithMessage("Mail maksımum 100 karakter olabilir.");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Username boş geçilemez").MaximumLength(20).WithMessage("username maksımum 20 karakter olmalıdır.");
            RuleFor(p => p.Paymentİnformation).NotEmpty().WithMessage("PaymentInformation boş geçilemez");

        }
    }
}
