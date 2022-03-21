using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.FilmKategori;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Concrete
{
    public class FilmKategoriService : IFilmKategoriService

    {
        private readonly NetflixDbContext _netflixDbContext;
        public FilmKategoriService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }



        public async Task<int> AddFilmKategori(AddFilmKategoriDto addFilmKategoriDto)
        {
            var addingFilmKategori = new FilmKategori
            {
                Type = addFilmKategoriDto.Type,
                CategoryName = addFilmKategoriDto.CategoryName

            };
            await _netflixDbContext.FilmKategoris.AddAsync(addingFilmKategori);
            return await _netflixDbContext.SaveChangesAsync();
        }



        public async Task<int> DeleteFilmKategori(int FilmKategoriId)
        {
            var currentFilmKategori = await _netflixDbContext.FilmKategoris.Where(p => !p.IsDeleted && p.Id == FilmKategoriId).FirstOrDefaultAsync();
            if (currentFilmKategori == null)
            {
                return -1;

            }
            currentFilmKategori.IsDeleted = true;
            _netflixDbContext.FilmKategoris.Update(currentFilmKategori);
            return await _netflixDbContext.SaveChangesAsync();


        }

        public async Task<List<GetListFilmKategoriDto>> GetAllFilmKategories()
        {
            return await _netflixDbContext.FilmKategoris.Where(p => !p.IsDeleted).Select(p => new GetListFilmKategoriDto
            {
                Id = p.Id,
                CategoryName = p.CategoryName,
                Type = p.Type

            }).ToListAsync();
        }

        public async Task<GetFilmKategoriDto> GetFilmKategoriById(int FilmKategoriId)
        {
            return await _netflixDbContext.FilmKategoris.Where(p => !p.IsDeleted && p.Id == FilmKategoriId).Select(p => new GetFilmKategoriDto
            {
                Id = p.Id,
                CategoryName = p.CategoryName,
                Type = p.Type
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateFilmKategori(UpdateFilmKategoriDto updateFilmKategoriDto)
        {
            var currentFilmKategori = await _netflixDbContext.FilmKategoris.Where(p => !p.IsDeleted && p.Id == updateFilmKategoriDto.Id).FirstOrDefaultAsync();
            if (currentFilmKategori == null)
            {
                return -1;

            }
            currentFilmKategori.CategoryName = updateFilmKategoriDto.CategoryName;
            currentFilmKategori.Name = updateFilmKategoriDto.Name;
            _netflixDbContext.FilmKategoris.Update(currentFilmKategori);
            return await _netflixDbContext.SaveChangesAsync();
        }
    }
}
