using FluentValidation;
using Netflix.DAL.Dto.FilmKategori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.FilmKategori
{
    public   class AddFilmKategoriValidator : AbstractValidator<AddFilmKategoriDto>
    {
        public AddFilmKategoriValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("CategoryName boş geçilemez.").MaximumLength(20).WithMessage("En fazla 20 karakter giriniz.");
            RuleFor(p => p.Type).NotEmpty().WithMessage("Type boş bırakılamaz.").MaximumLength(20).WithMessage("Maksımum 20 karakter girilebilir.");

        }
    }
}
