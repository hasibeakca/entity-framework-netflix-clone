using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.FilmKategori;
using Netflix.DAL.Dto.FilmKategori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmKategoriController : ControllerBase
    {
        private readonly IFilmKategoriService _filmKategoriService;
        public FilmKategoriController(IFilmKategoriService filmKategoriService)
        {
            _filmKategoriService = filmKategoriService;
        }
        [HttpGet]
        [Route("GetFilmKategoriList")]
        public async Task<ActionResult<List<GetListFilmKategoriDto>>> GetListFilmKategori()
        {

            try
            {
                return Ok(await _filmKategoriService.GetAllFilmKategories());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetFilmKategoriById/{id:int}")]
        public async Task<ActionResult<GetFilmKategoriDto>> GetFilmKategori(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GECERSIZ FİLMKATEGORİ IDSİ GİRDİNİZ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentFilmKategori = await _filmKategoriService.GetFilmKategoriById(id);
                if (currentFilmKategori == null)
                {
                    list.Add("FİLMKATEGORİ BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentFilmKategori;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddFilmKategori")]
        public async Task<ActionResult<string>> AddFilmKategoriDto(AddFilmKategoriDto addFilmKategoriDto)
        {
            var list = new List<string>();
            var validator = new AddFilmKategoriValidator();
            var validationResults = validator.Validate(addFilmKategoriDto);
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
                var result = await _filmKategoriService.AddFilmKategori(addFilmKategoriDto);

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
        [Route("UpdateFilmKategori")]
        public async Task<ActionResult<string>> UpdateFilmKategori(UpdateFilmKategoriDto updateFilmKategoriDto)
        {
            var list = new List<string>();
            var validator = new UpdateFilmKategoriValidator();
            var validationResults = validator.Validate(updateFilmKategoriDto);
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
                var result = await _filmKategoriService.UpdateFilmKategori(updateFilmKategoriDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("FİLMKATEGORİ BULUNAMADI");
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
        [Route("DeleteFilmKategori/{Id:int}")]
        public async Task<ActionResult<string>> DeleteFilmKategori(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _filmKategoriService.DeleteFilmKategori(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("FİLMKATEGORİ BULUNAMADI");
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
