using FluentValidation;
using Netflix.DAL.Dto.DiziKategoriDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Validation.DiziKategori
{
   public class UpdateDiziKategoriValidator : AbstractValidator<UpdateDiziKategoriDto>
    {
        public UpdateDiziKategoriValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("CategoryName boş geçilemez.").MaximumLength(50).WithMessage("Maksımum 50 karakter giriniz");
            RuleFor(p => p.Type).NotEmpty().WithMessage("Tyğpe boş geçilemez.").MaximumLength(20).WithMessage("Lutfen maksımum 20 karakter kullanınız.");
        }
    }
}
