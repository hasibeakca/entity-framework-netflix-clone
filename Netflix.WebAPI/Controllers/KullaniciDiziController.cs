using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.KullaniciDizi;
using Netflix.DAL.Dto.KullaniciDizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciDiziController : ControllerBase
    {
        private IKullaniciDiziService _kullaniciDiziService;
        public KullaniciDiziController(IKullaniciDiziService kullaniciDiziService)
        {
            _kullaniciDiziService = kullaniciDiziService;
        }
        [HttpGet]
        [Route("GetKullaniciDiziList")]
        public async Task<ActionResult<List<GetListKullaniciDiziDto>>> GetListKullaniciDizi()
        {

            try
            {
                return Ok(await _kullaniciDiziService.GetAllKullaniciDizis());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetKullaniciDiziById/{id:int}")]
        public async Task<ActionResult<GetKullaniciDiziDto>> GetKullaniciDizi(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GECERSIZ KULLANİCİDİZİ IDSİ GİRDİNİZ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentKullaniciDizi = await _kullaniciDiziService.GetKullaniciDiziById(id);
                if (currentKullaniciDizi == null)
                {
                    list.Add("KULLANİCİDİZİ BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentKullaniciDizi;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddKullaniciDizi")]
        public async Task<ActionResult<string>> AddKullaniciDiziDto(AddKullaniciDiziDto addKullaniciDiziDto)
        {
            var list = new List<string>();
            var validator = new AddKullaniciDiziValidator();
            var validationResults = validator.Validate(addKullaniciDiziDto);
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
                var result = await _kullaniciDiziService.AddKullaniciDizi(addKullaniciDiziDto);

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
        [Route("UpdateKullaniciDizi")]
        public async Task<ActionResult<string>> UpdateKullaniciDizi(UpdateKullaniciDiziDto updateKullaniciDiziDto)
        {
            var list = new List<string>();
            var validator = new UpdateKullaniciDiziValidator();
            var validationResults = validator.Validate(updateKullaniciDiziDto);
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
                var result = await _kullaniciDiziService.UpdateKullaniciDizi(updateKullaniciDiziDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("KULLANICIDİZİ BULUNAMADI");
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
        [Route("DeleteKullaniciDizi/{Id:int}")]
        public async Task<ActionResult<string>> DeleteKullaniciDizi(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _kullaniciDiziService.DeleteKullaniciDizi(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("KULLANİCİDİZİ BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else
                {
                    list.Add("SİLİNME BAŞARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
    }
}