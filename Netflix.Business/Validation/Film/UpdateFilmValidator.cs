using FluentValidation;
using Netflix.DAL.Dto.FilmDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.Film
{
  public  class UpdateFilmValidator : AbstractValidator<UpdateFilmDto>
    {
        public UpdateFilmValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name boş bırakılamaz.").MaximumLength(20).WithMessage("Maksımum 20 karakter giriniz.");
            RuleFor(p => p.Caption).NotEmpty().WithMessage("Caption boş bırakılamaz.").MaximumLength(100).WithMessage("maksımum 100 karakter giriniz.");
            RuleFor(p => p.Time).NotEmpty().WithMessage("Time boş geçilemez.");
            RuleFor(p => p.AgeRange).NotEmpty().WithMessage("AgeRange boş geçilemez.");

        }
    }
}
