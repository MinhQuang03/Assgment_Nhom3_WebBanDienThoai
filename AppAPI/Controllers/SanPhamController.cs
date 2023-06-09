using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SanPhamController : ControllerBase
{
    private ISanPhamServices sanPhamServices;

    public SanPhamController()
    {
        sanPhamServices = new SanPhamServices();
    }

    // GET: api/<SanPhamController>
    [HttpGet("get-all-sanpham")]
    public IEnumerable<SanPham> Get()
    {
        return sanPhamServices.GetAll();
    }

    // GET api/<SanPhamController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<SanPhamController>
    [HttpPost]
    public bool createSanPham(string ten, string moTa, string anh, Guid idHsx)
    {
        var sp = new SanPham()
        {
            Id = Guid.NewGuid(),
            TenSp = ten,
            MoTa = moTa,
            Anh = anh,
            IdHsx = idHsx
        };
        return sanPhamServices.createSanPham(sp);
    }

    // PUT api/<SanPhamController>/5
    [HttpPut("{id}")]
    public bool Put(Guid id, [FromBody] string ten, string moTa, string anh, Guid idHsx)
    {
        var sp = new SanPham()
        {
            Id = id,
            TenSp = ten,
            MoTa = moTa,
            Anh = anh,
            IdHsx = idHsx
        };
        return sanPhamServices.updateSanPham(sp);
    }

    // DELETE api/<SanPhamController>/5
    [HttpDelete("{id}")]
    public bool Delete(Guid id)
    {
        return sanPhamServices.deleteSanPham(id);
    }
}