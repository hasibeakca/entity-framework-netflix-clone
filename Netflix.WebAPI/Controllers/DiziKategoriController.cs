using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.DiziKategori;
using Netflix.DAL.Dto.DiziKategoriDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiziKategoriController : ControllerBase
    {
        private readonly IDiziKategoriService _diziKategoriService;

        public DiziKategoriController(IDiziKategoriService diziKategoriService)
        {
            _diziKategoriService = diziKategoriService;
        }
        [HttpGet]
        [Route("GetListDiziKategoriList")]
        public async Task<ActionResult<List<GetListDiziKategoriDto>>> GetListDiziKategori()
        {

            try
            {
                return Ok(await _diziKategoriService.GetAllDiziKategories());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetDiziKategoriById/{id:int}")]
        public async Task<ActionResult<GetDiziKategoriDto>> GetDiziKategori(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Gecersiz DiziKategori idsi girdiniz");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentDiziKategori = await _diziKategoriService.GetDiziKategoriById(id);
                if (currentDiziKategori == null)
                {
                    list.Add("DİZİKATEGORİ BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentDiziKategori;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddDiziKategori")]
        public async Task<ActionResult<string>> AddDiziKategoriDto(AddDiziKategoriDto addDiziKategoriDto)
        {
            var list = new List<string>();
            var validator = new AddDiziKategoriValidator();
            var validationResults = validator.Validate(addDiziKategoriDto);
            if (!validationResults.IsValid)
            {
                foreach(var error  in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }


            try
            {
                var result = await _diziKategoriService.AddDiziKategori(addDiziKategoriDto);

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
        [Route("UpdateDiziKategori")]
        public async Task<ActionResult<string>> UpdateDiziKategori(UpdateDiziKategoriDto updateDiziKategoriDto)
        {
            var list = new List<string>();
            var validator = new UpdateDiziKategoriValidator();
            var validationResult = validator.Validate(updateDiziKategoriDto);
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
                var result = await _diziKategoriService.UpdateDiziKategori(updateDiziKategoriDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("DİZİKATEGORİ BULUNAMADI");
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
        [Route("DeleteDiziKategori/{Id:int}")]
        public async Task<ActionResult<string>> DeleteDiziKategori(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _diziKategoriService.DeleteDiziKategori(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("DİZİKATEGORİ BULUNAMADI");
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
