using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Netflix.DAL.Dto.KullaniciFilm
{
    public class AddKullaniciFimDto : IDto
    {
        public int KullaniciId { get; set; }
        public int FilmId { get; set; }
    }
}
