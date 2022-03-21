using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.Dizi;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Concrete
{
    public class DiziService : IDiziService
    {
        private readonly NetflixDbContext _netflixDbContext;
        public DiziService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }


        public async Task<int> AddDizi(AddDiziDto addDiziDto)
        {
            var addingDizi = new Dizi
            {
                Name = addDiziDto.Name,
                Type = addDiziDto.Type,
                EpisodeNumber = addDiziDto.EpisodeNumber,
                SeasonNumber = addDiziDto.SeasonNumber,
                Imdb = addDiziDto.Imdb,
                DiziKategoriId = addDiziDto.DiziKategoriId

            };
            await _netflixDbContext.Diziler.AddAsync(addingDizi);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteDizi(int DiziId)
        {
            var currentDizi = await _netflixDbContext.Diziler.Where(p => !p.IsDeleted && p.Id == DiziId).FirstOrDefaultAsync();
            if (currentDizi == null)
            {
                return -1;

            }
            currentDizi.IsDeleted = true;
            _netflixDbContext.Diziler.Update(currentDizi);
            return await _netflixDbContext.SaveChangesAsync();

        }

        public async Task<List<GetListDiziDto>> GetAllDizis()
        {
            return await _netflixDbContext.Diziler.Include(p => p.DiziKategoriFK).Where(p => !p.IsDeleted).Select(p => new GetListDiziDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                SeasonNumber = p.SeasonNumber,
                EpisodeNumber = p.EpisodeNumber,
                AgeRange = p.AgeRange,
                Imdb = p.Imdb,
                DiziKategoriId = p.DiziKategoriId,
                DiziKategoriName = p.DiziKategoriFK.CategoryName
            }).ToListAsync();
        }

        public async Task<GetDiziDto> GetDiziById(int DiziId)
        {
            return await _netflixDbContext.Diziler.Include(p => p.DiziKategoriFK).Where(p => !p.IsDeleted && p.Id == DiziId).Select(p => new GetDiziDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                SeasonNumber = p.SeasonNumber,
                EpisodeNumber = p.EpisodeNumber,
                AgeRange = p.AgeRange,
                Imdb = p.Imdb,
                DiziKategoriId = p.DiziKategoriId,
                DiziKategoriName = p.DiziKategoriFK.CategoryName
            }).FirstOrDefaultAsync();


        }


        public async Task<int> UpdateDizi(UpdateDiziDto updateDiziDto)
        {
            var currentDizi = await _netflixDbContext.Diziler.Where(p => !p.IsDeleted && p.Id == updateDiziDto.Id).FirstOrDefaultAsync();
            if (currentDizi == null)
            {
                return -1;
            }

            currentDizi.Name = updateDiziDto.Name;
            currentDizi.SeasonNumber = updateDiziDto.SeasonNumber;
            currentDizi.EpisodeNumber = updateDiziDto.EpisodeNumber;
            currentDizi.Imdb = updateDiziDto.Imdb;
            currentDizi.AgeRange = updateDiziDto.AgeRange;
            currentDizi.Type = updateDiziDto.Type;
            currentDizi.DiziKategoriId = updateDiziDto.DiziKategoriId;

            _netflixDbContext.Diziler.Update(currentDizi);
            return await _netflixDbContext.SaveChangesAsync();

        }
    }
}
