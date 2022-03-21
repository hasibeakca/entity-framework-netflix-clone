using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.Kullanici;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Concrete
{
    public class KullaniciService : IKullaniciService
    {
        private readonly NetflixDbContext _netflixDbContext;
        public KullaniciService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }



        public async Task<int> AddKullanici(AddKullaniciDto addKullaniciDto)
        {
            var addingKullanici = new Kullanici
            {
                UserName = addKullaniciDto.UserName,
                Mail = addKullaniciDto.Mail,
                Paymentİnformation = addKullaniciDto.Paymentİnformation

            };
           await _netflixDbContext.Kullanicilar.AddAsync(addingKullanici);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteKullanici(int KullaniciId)
        {

            var currentKullanici = await _netflixDbContext.Kullanicilar.Where(p => !p.IsDeleted && p.Id == KullaniciId).FirstOrDefaultAsync();
            if (currentKullanici == null)
            {
                return -1;
            }
            currentKullanici.IsDeleted = true;
            _netflixDbContext.Kullanicilar.Update(currentKullanici);
            return await _netflixDbContext.SaveChangesAsync();



        }

        public async Task<List<GetListKullaniciDto>> GetAllKullanicis()
        {
            return await _netflixDbContext.Kullanicilar.Where(p => !p.IsDeleted).Select(p => new GetListKullaniciDto
            {
                Id = p.Id,
                UserName = p.UserName,
                Paymentİnformation = p.Paymentİnformation,
                Mail = p.Mail

            }
            ).ToListAsync();
        }

        public async Task<GetKullaniciDto> GetKullaniciById(int KullaniciId)
        {
            return await _netflixDbContext.Kullanicilar.Where(p => p.IsDeleted && p.Id == KullaniciId).Select(p => new GetKullaniciDto
            {
                Id = p.Id,
                UserName = p.UserName,
                Paymentİnformation = p.Paymentİnformation,
                Mail = p.Mail

            }
            ).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateKullanici(UpdateKullaniciDto updateKullaniciDto)
        {
            var currentKullanici = await _netflixDbContext.Kullanicilar.Where(p => !p.IsDeleted && p.Id == updateKullaniciDto.Id).FirstOrDefaultAsync();
            if (currentKullanici == null)
            {
                return -1;
            }
          
            currentKullanici.Mail = updateKullaniciDto.Mail;
            currentKullanici.UserName = updateKullaniciDto.UserName;
            currentKullanici.Paymentİnformation = updateKullaniciDto.Paymentİnformation;
            _netflixDbContext.Kullanicilar.Update(currentKullanici);
            return await _netflixDbContext.SaveChangesAsync();

        }
    }
}
