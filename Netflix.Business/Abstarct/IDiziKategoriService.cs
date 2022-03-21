using Netflix.DAL.Dto.DiziKategoriDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
  public  interface IDiziKategoriService
    {
       Task <List<GetListDiziKategoriDto>> GetAllDiziKategories();

        Task<GetDiziKategoriDto> GetDiziKategoriById(int DiziKategoriId);

        Task<int> AddDiziKategori(AddDiziKategoriDto addDiziKategoriDto);
        Task<int> UpdateDiziKategori(UpdateDiziKategoriDto updateDiziKategoriDto);

        Task<int> DeleteDiziKategori(int DiziKategoriId);
    }
}
