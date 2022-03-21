using Netflix.DAL.Dto.KullaniciFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
  public  interface IKullaniciFilmService
    {
        Task<List<GetListKullaniciFilmDto>> GetAllKullaniciFilms();

        Task<GetKullaniciFilmDto> GetKullaniciFilmById(int KullaniciFilmId);

        Task<int> AddKullaniciFilm(AddKullaniciFimDto addKullaniciFilmDto);
        Task<int> UpdateKullaniciFilm(UpdateKullaniciFilmDto updateKullaniciFilmDto);

        Task<int> DeleteKullaniciFilm(int KullaniciFilmId);
    }
}
