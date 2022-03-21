using Netflix.DAL.Dto.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Business.Abstarct
{
  public  interface IKullaniciService
    {
        Task<List<GetListKullaniciDto>> GetAllKullanicis();

        Task<GetKullaniciDto> GetKullaniciById(int KullaniciId);

        Task <int> AddKullanici(AddKullaniciDto addKullaniciDto);
        Task<int> UpdateKullanici(UpdateKullaniciDto updateKullaniciDto);

        Task<int> DeleteKullanici(int KullaniciId);
    }
}
