using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietSanPhamController : ControllerBase
    {
        public IChiTietSanPhamServices chiTietSanPhamServices { get; set; }

        public ChiTietSanPhamController()
        {
            chiTietSanPhamServices = new ChiTietSanPhamServices();
        }
        // GET: api/<ChiTietSanPhamController>
        [HttpGet("get-all-thongTin-SanPham")]
        public List<ChiTietSanPham> Get()
        {
            return chiTietSanPhamServices.GetAll();
        }

        // GET api/<ChiTietSanPhamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChiTietSanPhamController>
        [HttpPost("create-ThongTin-SanPham")]
        public bool Create(Guid IdSp, Guid IdGiamGia, Guid IdChatLieu, Guid IdBoNhoTrong, Guid IdHeDieuHanh, Guid IdCongSac, Guid IdPin, Guid IdSim,
            Guid IdRam, Guid IdChipCPU, Guid IdChipGPU, Guid IdMauSac, double TrongLuong, string CameraTruoc, string CameraSau, decimal DonGia, int TrangThai)
        {
            ChiTietSanPham a = new ChiTietSanPham()
            {
                Id = Guid.NewGuid(),
                IdSanPham = IdSp,
                IdGiamGia = IdGiamGia,
                IdChatLieu = IdChatLieu,
                IdBoNhoTrong = IdBoNhoTrong,
                IdHeDieuHanh = IdHeDieuHanh,
                IdCongSac = IdCongSac,
                IdPin = IdPin,
                IdSim = IdSim,
                IdRam = IdRam,
                IdChipCPU = IdChipCPU,
                IdChipGPU = IdChipGPU,
                IdMauSac = IdMauSac,
                TrongLuong = TrongLuong,
                CameraTruoc = CameraTruoc,
                CameraSau = CameraSau,
                DonGia = DonGia,
                TrangThai = TrangThai
            };
            return chiTietSanPhamServices.Create(a);
        }

        // PUT api/<ChiTietSanPhamController>/5
        [HttpPut("update-ThongTinSanPham-{id}")]
        public bool update(Guid id, [FromBody] Guid IdSp, Guid IdGiamGia, Guid IdChatLieu, Guid IdBoNhoTrong, Guid IdHeDieuHanh, Guid IdCongSac, Guid IdPin, Guid IdSim,
            Guid IdRam, Guid IdChipCPU, Guid IdChipGPU, Guid IdMauSac, double TrongLuong, string CameraTruoc, string CameraSau, decimal DonGia, int TrangThai)
        {
            ChiTietSanPham a = new ChiTietSanPham()
            {
                Id = id,
                IdSanPham = IdSp,
                IdGiamGia = IdGiamGia,
                IdChatLieu = IdChatLieu,
                IdBoNhoTrong = IdBoNhoTrong,
                IdHeDieuHanh = IdHeDieuHanh,
                IdCongSac = IdCongSac,
                IdPin = IdPin,
                IdSim = IdSim,
                IdRam = IdRam,
                IdChipCPU = IdChipCPU,
                IdChipGPU = IdChipGPU,
                IdMauSac = IdMauSac,
                TrongLuong = TrongLuong,
                CameraTruoc = CameraTruoc,
                CameraSau = CameraSau,
                DonGia = DonGia,
                TrangThai = TrangThai
            };
            return chiTietSanPhamServices.Update(a);
        }

        // DELETE api/<ChiTietSanPhamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
