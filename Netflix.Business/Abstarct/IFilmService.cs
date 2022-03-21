using Netflix.DAL.Dto.FilmDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
   public interface IFilmService
    {
        Task<List<GetListFilmDto>> GetAllFilms();

        Task<GetFilmDto> GetFilmById(int FilmId);

        Task<int> AddFilm(AddFilmDto addFilmDto);
        Task<int> UpdateFilm(UpdateFilmDto updateFilmDto);

        Task<int> DeleteFilm(int FilmId);
    }
}
