using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.FilmDto;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Concrete
{
    public class FilmService : IFilmService
    {
        private readonly NetflixDbContext _netflixDbContext;
        public FilmService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }


        public async Task<int> AddFilm(AddFilmDto addFilmDto)
        {
            var addingFilm = new Film
            {
                Name = addFilmDto.Name,
                AgeRange = addFilmDto.AgeRange,
                Caption = addFilmDto.Caption,
                Time = addFilmDto.Time,
                FilmKategoriId = addFilmDto.FilmKategoriId
            };
            await _netflixDbContext.Filmler.AddAsync(addingFilm);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteFilm(int FilmId)
        {
            var currentDizi = await _netflixDbContext.Filmler.Where(p => p.IsDeleted && p.Id == FilmId).FirstOrDefaultAsync();
            if (currentDizi == null)
            {
                return -1;
            }
            currentDizi.IsDeleted = true;
            _netflixDbContext.Filmler.Update(currentDizi);
            return await _netflixDbContext.SaveChangesAsync();

        }

        public async Task<List<GetListFilmDto>> GetAllFilms()
        {
            return await _netflixDbContext.Filmler.Include(p => p.FilmKategoriFK).Where(p => p.IsDeleted).Select(p => new GetListFilmDto
            {
                Id = p.Id,
                Name = p.Name,
                AgeRange = p.AgeRange,
                Caption = p.Caption,
                Time = p.Time,
                FilmKategoriId = p.FilmKategoriId,
                FilmKategoriName = p.FilmKategoriFK.CategoryName

            }).ToListAsync();

        }

        public async Task<GetFilmDto> GetFilmById(int FilmId)
        {
            return await _netflixDbContext.Filmler.Include(p => p.FilmKategoriFK).Where(p => p.IsDeleted && p.Id == FilmId).Select(p => new GetFilmDto
            {
                Id = p.Id,
                Name = p.Name,
                AgeRange = p.AgeRange,
                Caption = p.Caption,
                Time = p.Time,
                FilmKategoriId = p.FilmKategoriId,
                FilmKategoriName = p.FilmKategoriFK.CategoryName
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateFilm(UpdateFilmDto updateFilmDto)
        {
            var currentFilm = await _netflixDbContext.Filmler.Where(p => p.IsDeleted && p.Id == updateFilmDto.Id).FirstOrDefaultAsync();
            if (currentFilm == null)
            {
                return -1;
            }

            currentFilm.Name = updateFilmDto.Name;
            currentFilm.Time = updateFilmDto.Time;
            currentFilm.AgeRange = updateFilmDto.AgeRange;
            currentFilm.Caption = updateFilmDto.Caption;
            currentFilm.FilmKategoriId = updateFilmDto.FilmKategoriId;

            _netflixDbContext.Filmler.Update(currentFilm);
            return await _netflixDbContext.SaveChangesAsync();

        }
    }
}
