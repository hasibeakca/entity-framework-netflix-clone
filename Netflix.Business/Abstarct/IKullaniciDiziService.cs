using Netflix.DAL.Dto.KullaniciDizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
    public interface IKullaniciDiziService
    {
        Task<List<GetListKullaniciDiziDto>> GetAllKullaniciDizis();

        Task<GetKullaniciDiziDto> GetKullaniciDiziById(int KullaniciDiziId);

        Task<int> AddKullaniciDizi(AddKullaniciDiziDto addKullaniciDiziDto);
        Task<int> UpdateKullaniciDizi(UpdateKullaniciDiziDto updateKullaniciDiziDto);

        Task<int> DeleteKullaniciDizi(int KullaniciDiziId);
    }
}
