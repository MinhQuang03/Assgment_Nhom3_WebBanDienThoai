using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class NhaSanXuatController : ControllerBase
    {
        private INhaSanXuatServices nhaSanXuatServices;

        public NhaSanXuatController()
        {
            nhaSanXuatServices = new NhaSanXuatServices();
        }
        // GET: api/<NhaSanXuatController>
        [HttpGet("get-all-nhasanxuat")]
        public List<NhaSanXuat> Get()
        {
            return nhaSanXuatServices.GetAll();
        }

        // GET api/<NhaSanXuatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NhaSanXuatController>
        [HttpPost("create-nhasanxuat")]
        public bool CreateNhaSanXuat( string ten)
        {
            NhaSanXuat nsx = new NhaSanXuat()
            {
                Id = Guid.NewGuid(),
                Ten = ten,
            };
            return nhaSanXuatServices.createNhaSanXuat(nsx);
        }

        // PUT api/<NhaSanXuatController>/5
        [HttpPut("update-nhasanxuat-{id}")]
        public bool UpdateNhaSanXuat(Guid id, [FromBody] string ten)
        {
            NhaSanXuat nsx = new NhaSanXuat()
            {
                Id = id,
                Ten = ten,
            };
            return nhaSanXuatServices.updateNhaSanXuat(nsx);
        }

        // DELETE api/<NhaSanXuatController>/5
        [HttpDelete("delete-nhasanxuat-{id}")]
        public bool Delete(Guid id)
        {
            return nhaSanXuatServices.deleteSanPham(id);
        }
    }
}
