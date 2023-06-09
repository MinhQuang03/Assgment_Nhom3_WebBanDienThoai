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
    [HttpPost("create-SanPham")]
    public bool createSanPham(SanPham a)
    {
        SanPham sp = new SanPham()
        {
            Id = Guid.NewGuid(),
            TenSp = a.TenSp,
            MoTa = a.MoTa,
            Anh = a.Anh,
            IdHsx = a.IdHsx,
        };
       return sanPhamServices.createSanPham(sp);
    }



    [HttpPost("create-SanPham-img")]
    public bool createSanPhamImg(SanPham a, IFormFile imageFile)
    {
        SanPham sp = new SanPham()
        {
            Id = Guid.NewGuid(),
            TenSp = a.TenSp,
            MoTa = a.MoTa,
            Anh = a.Anh,
            IdHsx = a.IdHsx,
        };
        if (imageFile != null && imageFile.Length > 0) // khong null va khong trong 
        {
            // Tro toi thu muc wwwroot de lat nua thuc hien viec Copy sang 
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                // Thuc hien copy anh vua chon sang thu muc moi (wwwroot)
                imageFile.CopyTo(stream);
            }
            // Gan lai gia tri cho Image cua doi tuong bang ten file anh da duoc sao chep
            sp.Anh = imageFile.FileName;
        }
        
        return sanPhamServices.createSanPham(sp);
    }







    // PUT api/<SanPhamController>/5
    [HttpPut("update-SanPham-{id}")]
    public bool Put(Guid id, [FromBody] string ten,string moTa,string anh,Guid idHsx)
    {
        SanPham sp = new SanPham()
        {
            Id = id,
            TenSp = ten,
            MoTa = moTa,
            Anh = anh,
            IdHsx = idHsx,
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