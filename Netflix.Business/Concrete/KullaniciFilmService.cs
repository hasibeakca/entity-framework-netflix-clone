using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.KullaniciFilm;
using Netflix.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Concrete
{
    public class KullaniciFilmService : IKullaniciFilmService
    {
        private readonly NetflixDbContext _netflixDbContext;
        public KullaniciFilmService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }


        public async Task<int> AddKullaniciFilm(AddKullaniciFimDto addKullaniciFilmDto)
        {
            var addingKullaniciFilm = new KullaniciFilm
            {
                KullaniciId = addKullaniciFilmDto.KullaniciId,
                FilmId = addKullaniciFilmDto.FilmId
            };
           await _netflixDbContext.KullaniciFilms.AddAsync(addingKullaniciFilm);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteKullaniciFilm(int KullaniciFilmId)
        {
            var currentKullaniciFilm = await _netflixDbContext.KullaniciFilms.Where(p => !p.IsDeleted && p.Id == KullaniciFilmId).FirstOrDefaultAsync();
            if (currentKullaniciFilm == null)
            {
                return -1;
            }
            currentKullaniciFilm.IsDeleted = true;
            _netflixDbContext.KullaniciFilms.Update(currentKullaniciFilm);
            return await _netflixDbContext.SaveChangesAsync();

        }

        public async Task< List<GetListKullaniciFilmDto>> GetAllKullaniciFilms()
        {
            return await _netflixDbContext.KullaniciFilms.Include(p => p.KullaniciFK).Include(p => p.FilmFK).Where(p => !p.IsDeleted).Select(p => new GetListKullaniciFilmDto
            {
                Id = p.Id,
                UserName = p.KullaniciFK.UserName,
                Mail = p.KullaniciFK.Mail,
                Paymentİnformation = p.KullaniciFK.Paymentİnformation,

                Name = p.FilmFK.Name,
                Caption = p.FilmFK.Caption,
                Time = p.FilmFK.Time

            }).ToListAsync();
        }

        public async Task< GetKullaniciFilmDto> GetKullaniciFilmById(int KullaniciFilmId)
        {
            return await _netflixDbContext.KullaniciFilms.Include(p => p.KullaniciFK).Include(p => p.FilmFK).Where(p => !p.IsDeleted && p.Id == KullaniciFilmId).Select(p => new GetKullaniciFilmDto
            {
                Id = p.Id,
                UserName = p.KullaniciFK.UserName,
                Mail = p.KullaniciFK.Mail,
                Paymentİnformation = p.KullaniciFK.Paymentİnformation,

                Name = p.FilmFK.Name,
                Caption = p.FilmFK.Caption,
                Time = p.FilmFK.Time

            }).FirstOrDefaultAsync();


        }

        public async Task< int> UpdateKullaniciFilm(UpdateKullaniciFilmDto updateKullaniciFilmDto)
        {
            var currentKullaniciFilm = await _netflixDbContext.KullaniciFilms.Where(p => !p.IsDeleted && p.Id == updateKullaniciFilmDto.Id).FirstOrDefaultAsync();
            if (currentKullaniciFilm == null)
            {
                return -1;
            }
          
            currentKullaniciFilm.KullaniciId = updateKullaniciFilmDto.KullaniciId;
            currentKullaniciFilm.FilmId = updateKullaniciFilmDto.FilmId;

            _netflixDbContext.KullaniciFilms.Update(currentKullaniciFilm);
            return await _netflixDbContext.SaveChangesAsync();
        }
    }
}
