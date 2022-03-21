using FluentValidation;
using Netflix.DAL.Dto.KullaniciDizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.KullaniciDizi
{
   public class UpdateKullaniciDiziValidator : AbstractValidator<UpdateKullaniciDiziDto>
    {
        public UpdateKullaniciDiziValidator()
        {
            RuleFor(p => p.DiziId).NotEmpty().WithMessage("Dizi ıd boş geçilemez.");
            RuleFor(p => p.KullaniciId).NotEmpty().WithMessage("Kullanıcı ıd boş geçilemez.");
        }
    }
}
