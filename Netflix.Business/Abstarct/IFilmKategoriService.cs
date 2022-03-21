using Netflix.DAL.Dto.FilmKategori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
  public  interface IFilmKategoriService
    {
       Task< List<GetListFilmKategoriDto>> GetAllFilmKategories();

        Task<GetFilmKategoriDto> GetFilmKategoriById(int FilmKategoriId);

        Task<int> AddFilmKategori(AddFilmKategoriDto addFilmKategoriDto);
        Task<int> UpdateFilmKategori(UpdateFilmKategoriDto updateFilmKategoriDto);

        Task<int> DeleteFilmKategori(int FilmKategoriId);
    }
}
