using FluentValidation;
using Netflix.DAL.Dto.KullaniciFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.KullaniciFilm
{
 public   class UpdateKullaniciFilmValidator : AbstractValidator<UpdateKullaniciFilmDto>
    {
        public UpdateKullaniciFilmValidator()
        {
            RuleFor(p => p.FilmId).NotEmpty().WithMessage("FilmId boş geçilemez.");
            RuleFor(p => p.KullaniciId).NotEmpty().WithMessage("KullaniciId boş geçilemez.");
        }
    }
}
