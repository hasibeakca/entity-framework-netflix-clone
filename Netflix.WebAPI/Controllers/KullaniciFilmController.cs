using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.KullaniciFilm;
using Netflix.DAL.Dto.KullaniciFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciFilmController : ControllerBase
    {
        private readonly IKullaniciFilmService _kullaniciFilmService;
        public KullaniciFilmController(IKullaniciFilmService kullaniciFilmService)
        {
            _kullaniciFilmService = kullaniciFilmService;
        }
        [HttpGet]
        [Route("GetKullaniciFilmList")]
        public async Task<ActionResult<List<GetListKullaniciFilmDto>>> GetListKullaniciFilm()
        {

            try
            {
                return Ok(await _kullaniciFilmService.GetAllKullaniciFilms());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetKullaniciFilmById/{id:int}")]
        public async Task<ActionResult<GetKullaniciFilmDto>> GetKullaniciFilm(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GECERSIZ KULLANİCİFİLM IDSİ GİRDİNİZ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentKullaniciFilm = await _kullaniciFilmService.GetKullaniciFilmById(id);
                if (currentKullaniciFilm == null)
                {
                    list.Add("KULLANİCİFİLM BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentKullaniciFilm;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddKullaniciFilm")]
        public async Task<ActionResult<string>> AddKullaniciFilmDto(AddKullaniciFimDto addKullaniciFilmDto)
        {
            var list = new List<string>();
            var validator = new AddKullaniciFilmValidator();
            var validationResults = validator.Validate(addKullaniciFilmDto);
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
                var result = await _kullaniciFilmService.AddKullaniciFilm(addKullaniciFilmDto);

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
        [HttpDelete]
        [Route("DeleteKullaniciFilm/{Id:int}")]
        public async Task<ActionResult<string>> DeleteKullaniciFilm(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _kullaniciFilmService.DeleteKullaniciFilm(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("KULLANİCİFİLM BULUNAMADI");
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
        [HttpPut]
        [Route("UpdateKullaniciFilm")]
        public async Task<ActionResult<string>> UpdateDizi(UpdateKullaniciFilmDto updateKullaniciFilmDto)
        {
            var list = new List<string>();
            var validator = new UpdateKullaniciFilmValidator();
            var validaitonResults = validator.Validate(updateKullaniciFilmDto);
            if (!validaitonResults.IsValid)
            {
                foreach (var error in validaitonResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
           
            try
            {
                var result = await _kullaniciFilmService.UpdateKullaniciFilm(updateKullaniciFilmDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("DIZI BULUNAMADI");
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
    }
}
