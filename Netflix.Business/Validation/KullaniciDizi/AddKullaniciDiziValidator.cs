using FluentValidation;
using Netflix.DAL.Dto.KullaniciDizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.KullaniciDizi
{
  public  class AddKullaniciDiziValidator : AbstractValidator<AddKullaniciDiziDto>
    {
        public AddKullaniciDiziValidator()
        {
            RuleFor(p => p.DiziId).NotEmpty().WithMessage("DiziId boş geçilemez.");
            RuleFor(p => p.KullaniciId).NotEmpty().WithMessage("KullaniciId boş geçilemez.");


        }
    }
}
