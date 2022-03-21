using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstarct;
using Netflix.Business.Validation.Dizi;
using Netflix.DAL.Dto.Dizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiziController : ControllerBase
    {
        private readonly IDiziService _diziService;
        public DiziController(IDiziService diziService)
        {
            _diziService = diziService;
        }
        [HttpGet]
        [Route("GetDiziList")]
        public async Task<ActionResult<List<GetListDiziDto>>> GetListDizi()
        {

            try
            {
                return Ok(await _diziService.GetAllDizis());
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetDiziById/{id:int}")]
        public async Task<ActionResult<GetDiziDto>> GetDizi(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GECERSIZ DİZİ IDSİ GİRDİNİZ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentDizi = await _diziService.GetDiziById(id);
                if (currentDizi == null)
                {
                    list.Add("DİZİ BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentDizi;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
        [HttpPost("AddDizi")]
        public async Task<ActionResult<string>> AddDiziDto(AddDiziDto addDiziDto)
        {
            var list = new List<string>();
            var validator = new AddDiziValidator();
            var validationResults = validator.Validate(addDiziDto);
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
                var result = await _diziService.AddDizi(addDiziDto);

                if (result>0)
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
        [Route("UpdateDizi")]
        public async Task<ActionResult<string>> UpdateDizi(UpdateDiziDto updateDiziDto)
        {
            var list = new List<string>();
            var validator = new UpdateDiziValidator();
            var validationResults = validator.Validate(updateDiziDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
             
                }
                return Ok(new { codee = StatusCode(1002), message = list, type = "error" });
            }
            

            try
            {
                var result = await _diziService.UpdateDizi(updateDiziDto);
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

        [HttpDelete]
        [Route("DeleteDizi/{Id:int}")]
        public async Task<ActionResult<string>> DeleteDizi(int Id)
        {
            var list = new List<string>(); 
            try
            {
                var result = await _diziService.DeleteDizi(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("DİZİ BULUNAMADI");
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
