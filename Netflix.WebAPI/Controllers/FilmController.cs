using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.Film;
using Netflix.DAL.Dto.FilmDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        [Route("GetFilmList")]
        public async Task<ActionResult<List<GetListFilmDto>>> GetListFilm()
        {

            try
            {
                return Ok(await _filmService.GetAllFilms());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetFilmById/{id:int}")]
        public async Task<ActionResult<GetFilmDto>> GetFilm(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GECERSIZ FİLM IDSİ GİRDİNİZ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentFilm = await _filmService.GetFilmById(id);
                if (currentFilm == null)
                {
                    list.Add("FİLM BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentFilm;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddFilm")]
        public async Task<ActionResult<string>> AddFilmDto(AddFilmDto addFilmDto)
        {
            var list = new List<string>();
            var validator = new AddFilmValidator();
            var validationResults = validator.Validate(addFilmDto);
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
                var result = await _filmService.AddFilm(addFilmDto);

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
            [Route("DeleteFilm/{Id:int}")]
            public async Task<ActionResult<string>> DeleteFilm(int Id)
            {
                var list = new List<string>();
                try
                {
                    var result = await _filmService.DeleteFilm(Id);
                    if (result > 0)
                    {
                        list.Add("SİLİNME BASARILI");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                    }
                    else if (result == -1)
                    {
                        list.Add("FİLM BULUNAMADI");
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
        [Route("UpdateFilm")]
        public async Task<ActionResult<string>> UpdateFilm(UpdateFilmDto updateFilmDto)
        {
            var list = new List<string>();
            var validator = new UpdateFilmValidator();
            var validationResult = validator.Validate(updateFilmDto);
            if (!validationResult.IsValid)
            {
                foreach(var error in validationResult.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _filmService.UpdateFilm(updateFilmDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("FİLM BULUNAMADI");
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
        

