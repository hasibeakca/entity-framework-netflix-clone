using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.KullaniciDizi;
using Netflix.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Concrete
{
    public class KullaniciDiziService : IKullaniciDiziService
    {
        private readonly NetflixDbContext _netflixDbContext;
        public KullaniciDiziService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }





        public async Task<int> AddKullaniciDizi(AddKullaniciDiziDto addKullaniciDiziDto)
        {
            var addingKullaniciDizi = new KullaniciDizi
            { //ZATEN BİLGİLER TUTULUYOR VERI TEKRARINI ENGELLEMEK ICIN SADECE PRIMARY KEYLERI ALDIK
                KullaniciId = addKullaniciDiziDto.KullaniciId,
                DiziId = addKullaniciDiziDto.DiziId

            };
           await _netflixDbContext.KullaniciDizis.AddAsync(addingKullaniciDizi);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteKullaniciDizi(int KullaniciDiziId)
        {
            var currentKullaniciDizi = await _netflixDbContext.KullaniciDizis.Where(p => !p.IsDeleted && p.Id == KullaniciDiziId).FirstOrDefaultAsync();
            if (currentKullaniciDizi == null)
            {
                return -1;
            }
            currentKullaniciDizi.IsDeleted = true;
            _netflixDbContext.KullaniciDizis.Update(currentKullaniciDizi);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListKullaniciDiziDto>> GetAllKullaniciDizis()
        {
            return await _netflixDbContext.KullaniciDizis.Include(p => p.KullaniciFK).Include(p => p.DiziFK).Where(p => !p.IsDeleted).Select(p => new GetListKullaniciDiziDto
            {
                Id = p.Id,
                UserName = p.KullaniciFK.UserName,
                Mail = p.KullaniciFK.Mail,
                Paymentİnformation = p.KullaniciFK.Paymentİnformation,

                Name = p.DiziFK.Name,
                Type = p.DiziFK.Type,
                EpisodeNumber = p.DiziFK.EpisodeNumber,
                SeasonNumber = p.DiziFK.SeasonNumber,
                Imdb = p.DiziFK.Imdb,
                AgeRange = p.DiziFK.AgeRange
            }).ToListAsync();
        }

        public async Task<GetKullaniciDiziDto> GetKullaniciDiziById(int KullaniciDiziId)
        {
            return await _netflixDbContext.KullaniciDizis.Include(p => p.KullaniciFK).Include(p => p.DiziFK).Where(p => !p.IsDeleted && p.Id == KullaniciDiziId).Select(p => new GetKullaniciDiziDto
            {
                UserName = p.KullaniciFK.UserName,
                Mail = p.KullaniciFK.Mail,
                Paymentİnformation = p.KullaniciFK.Paymentİnformation,
                Id= p.Id,
                Name = p.DiziFK.Name,
                Type = p.DiziFK.Type,
                EpisodeNumber = p.DiziFK.EpisodeNumber,
                SeasonNumber = p.DiziFK.SeasonNumber,
                Imdb = p.DiziFK.Imdb,
                AgeRange = p.DiziFK.AgeRange
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateKullaniciDizi(UpdateKullaniciDiziDto updateKullaniciDiziDto)
        {
            var currentKullaniciDizi = await _netflixDbContext.KullaniciDizis.Where(p => !p.IsDeleted && p.Id == updateKullaniciDiziDto.Id).FirstOrDefaultAsync();
            if (currentKullaniciDizi == null)
            {
                return -1;
            }
          
            currentKullaniciDizi.DiziId = updateKullaniciDiziDto.DiziId;
            currentKullaniciDizi.KullaniciId = updateKullaniciDiziDto.KullaniciId;
            _netflixDbContext.KullaniciDizis.Update(currentKullaniciDizi);
            return await _netflixDbContext.SaveChangesAsync();
        }
    }
}
