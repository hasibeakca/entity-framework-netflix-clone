using Netflix.DAL.Dto.Dizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
   public interface IDiziService
    {
        Task<List<GetListDiziDto>> GetAllDizis();

        Task<GetDiziDto> GetDiziById(int DiziId);

        Task<int> AddDizi(AddDiziDto addDiziDto);
        Task<int> UpdateDizi(UpdateDiziDto updateDiziDto);

        Task<int> DeleteDizi(int DiziId);
    }
}
