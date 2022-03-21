using Microsoft.EntityFrameworkCore;
using Netflix.Business.Abstarct;
using Netflix.DAL.Context;
using Netflix.DAL.Dto.DiziKategoriDto;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Netflix.Business.Concrete
{
    public class DiziKategoriService : IDiziKategoriService
    {
        private readonly NetflixDbContext _netflixDbContext;
        public DiziKategoriService(NetflixDbContext netflixDbContext)
        {
            _netflixDbContext = netflixDbContext;
        }

        public async Task<int> AddDiziKategori(AddDiziKategoriDto addDiziKategoriDto)
        {
            var AddingDiziKategori = new DiziKategori
            {
                CategoryName = addDiziKategoriDto.CategoryName,
                Type = addDiziKategoriDto.Type
            };
           await _netflixDbContext.DiziKategoriler.AddAsync(AddingDiziKategori);
            return await _netflixDbContext.SaveChangesAsync();
        }




        public async Task<int> DeleteDiziKategori(int DiziKategoriId)
        {
            var currentDiziKategori = _netflixDbContext.DiziKategoriler.Where(p => !p.IsDeleted && p.Id == DiziKategoriId).FirstOrDefault();
            if (currentDiziKategori == null)
            {
                return -1;
            }
            currentDiziKategori.IsDeleted = true;
            _netflixDbContext.DiziKategoriler.Update(currentDiziKategori);
            return await _netflixDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListDiziKategoriDto>> GetAllDiziKategories()
        {
            return await _netflixDbContext.DiziKategoriler.Where(p => !p.IsDeleted).Select(p => new GetListDiziKategoriDto
            {
                Id = p.Id,
                CategoryName = p.CategoryName,
                Type = p.Type


            }
            ).ToListAsync();


        }

        public async Task<GetDiziKategoriDto> GetDiziKategoriById(int DiziKategoriId)
        {
            return await _netflixDbContext.DiziKategoriler.Where(p => !p.IsDeleted && p.Id == DiziKategoriId).Select(p => new GetDiziKategoriDto
            {
                Id = p.Id,
                CategoryName = p.CategoryName,
                Type = p.Type


            }).FirstOrDefaultAsync();

        }

        public async Task<int> UpdateDiziKategori(UpdateDiziKategoriDto updateDiziKategoriDto)
        {
            var currentDiziKategori = await _netflixDbContext.DiziKategoriler.Where(p => !p.IsDeleted && p.Id == updateDiziKategoriDto.Id).FirstOrDefaultAsync();
            if (currentDiziKategori == null)
            {
                return -1;
            }
            
            currentDiziKategori.Type = updateDiziKategoriDto.Type;
            currentDiziKategori.CategoryName = updateDiziKategoriDto.CategoryName;
            _netflixDbContext.DiziKategoriler.Update(currentDiziKategori);
            return await _netflixDbContext.SaveChangesAsync();
        }
    }
}
