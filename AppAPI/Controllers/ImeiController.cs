using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImeiController : ControllerBase
    {
        public IImeiServices imeiServices { get; set; }

        public ImeiController()
        {
            imeiServices = new ImeiServices();
        }
        // GET: api/<ImeiController>
        [HttpGet]
        [HttpGet("get-all-Imei")]
        public List<Imei> Get()
        {
            return imeiServices.GetAll();
        }

       
        // POST api/<ImeiController>
        [HttpPost("create-imei")]
        public bool Create(string ten, int TrangThai, Guid IdCtsp)
        {
            Imei a = new Imei()
            {
                Id = Guid.NewGuid(),
                imei = ten,
                TrangThai = TrangThai,
                IdCtsp = IdCtsp
            };
            return imeiServices.Create(a);
        }

        // PUT api/<ImeiController>/5
        [HttpPut("update-imei-{id}")]
        public bool update(Guid id, string ten, int TrangThai)
        {
            Imei a = new Imei()
            {
                Id = id,
                imei = ten,
                TrangThai = TrangThai,
              
            };
            return imeiServices.Update(a);
        }

        // DELETE api/<ImeiController>/5
        [HttpDelete("delete-imei-{id}")]
        public bool Delete(Guid id)
        {
            return imeiServices.Delete(id);
        }
    }
}
