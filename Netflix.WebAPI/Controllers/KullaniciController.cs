using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.Kullanici;
using Netflix.DAL.Dto.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        [HttpGet]
        [Route("GetKullaniciList")]
        public async Task<ActionResult<List<GetListKullaniciDto>>> GetListKullanici()
        {

            try
            {
                return Ok(await _kullaniciService.GetAllKullanicis());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetKullaniciById/{id:int}")]
        public async Task<ActionResult<GetKullaniciDto>> GetKullanici(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GECERSIZ KULLANİCİ IDSİ GİRDİNİZ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentKullanici = await _kullaniciService.GetKullaniciById(id);
                if (currentKullanici == null)
                {
                    list.Add("KULLANİCİ BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentKullanici;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddKullanici")]
        public async Task<ActionResult<string>> AddKullaniciDto(AddKullaniciDto addKullaniciDto)
        {
            var list = new List<string>();
            var validator = new AddKullaniciValidator();
            var validationResults = validator.Validate(addKullaniciDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _kullaniciService.AddKullanici(addKullaniciDto);

                if (result > 0)
                {
                    list.Add("EKLEME ISLEMI BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "succcess" });
                }
                else
                {
                    list.Add("EKLEME ISLEMI BASARISIZ.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPut]
        [Route("UpdateKullanici")]
        public async Task<ActionResult<string>> UpdateKullanici(UpdateKullaniciDto updateKullaniciDto)
        {
            var list = new List<string>();
            var validator = new UpdateKullaniciValidator();
            var validationResults = validator.Validate(updateKullaniciDto);
            if (!validationResults.IsValid)
            {
                foreach(var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _kullaniciService.UpdateKullanici(updateKullaniciDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("KULLANICI BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Guncelleme basarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }


            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteKullanici/{Id:int}")]
        public async Task<ActionResult<string>> DeleteKullanici(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _kullaniciService.DeleteKullanici(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("KULLANICI BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else
                {
                    list.Add("SİLİNME BAŞARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }

            }
            catch (Exception aaaaa)
            {

                return BadRequest(aaaaa.Message);
            }
        }
    }
}
