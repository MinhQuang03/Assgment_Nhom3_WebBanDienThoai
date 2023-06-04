using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        public readonly IGiamGiaServices giamGiaServices;
        public GiamGiaController()
        {
            giamGiaServices = new GiamGiaServices();
        }

        // GET: api/<GiamGiaController>
        [HttpGet("get-all-MaGiamGia")]
        public List<GiamGia> Get()
        {
            return giamGiaServices.GetAll();
        }

        // GET api/<GiamGiaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GiamGiaController>
        [HttpPost("create-MaGiamGia")]
        public bool Create(GiamGia gg)
        {
            GiamGia a = new GiamGia()
            {
                Id = Guid.NewGuid(),
                SoPhanTramGiam = gg.SoPhanTramGiam,
                NgayBatDau = gg.NgayBatDau,
                NgayKetThuc = gg.NgayKetThuc,
                GhiChu = gg.GhiChu,
                TrangThai = gg.TrangThai
            };
            return giamGiaServices.Create(a);
        }

        // PUT api/<GiamGiaController>/5
        [HttpPut("update-MaGiamGia-{id}")]
        public bool update(Guid id, [FromBody] decimal SoPhanTram, DateTime NgayBatDau, DateTime NgayKetThuc, string GhiChu, int TrangThai)
        {
            GiamGia a = new GiamGia()
            {
                Id = id,
                SoPhanTramGiam = SoPhanTram,
                NgayBatDau = NgayBatDau,
                NgayKetThuc = NgayKetThuc,
                GhiChu = GhiChu,
                TrangThai = TrangThai
            };
            return giamGiaServices.Update(a);
        }

        // DELETE api/<GiamGiaController>/5
        [HttpDelete("delete-MaGiamGia-{id}")]
        public bool Delete(Guid id)
        {
            return giamGiaServices.Delete(id);
        }
    }
}
