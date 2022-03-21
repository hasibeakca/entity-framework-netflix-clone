using FluentValidation;
using Netflix.DAL.Dto.Dizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.Dizi
{
    public class UpdateDiziValidator : AbstractValidator<UpdateDiziDto>
    {
        public UpdateDiziValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Dizi adı boş bırakılamaz.").MaximumLength(100).WithMessage("Maksımum 100 karakter giriniz.");
            RuleFor(p => p.SeasonNumber).NotEmpty().WithMessage("SeasonNumber boş bırakılamaz.");
            RuleFor(p => p.EpisodeNumber).NotEmpty().WithMessage("EpisodeNumber boş bırakılamaz.");
            RuleFor(p => p.AgeRange).NotEmpty().WithMessage("AgeRange boş bırakılamaz.");
            RuleFor(p => p.Imdb).NotEmpty().WithMessage("Imdb boş bırakılamaz.");
        }
    }
}
