using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LstAnhController : ControllerBase
    {
        private ILstAnhService _lstAnh;

        public LstAnhController()
        {
            _lstAnh = new LstAnhService();
        }
        // GET: api/<LstAnhController>
        [HttpGet]
        public IEnumerable<ListAnh> Get()
        {
            return _lstAnh.GetAll();
        }

        // GET api/<LstAnhController>/5
        [HttpGet("get-by-id/{id}")]
        public ListAnh GetById(Guid id)
        {
            return _lstAnh.GetById(id);
        }

        // POST api/<LstAnhController>
        [HttpPost("create-anh")]
        public bool Post([FromBody] ListAnh anh)
        {
            return _lstAnh.Create(anh);
        }

        // PUT api/<LstAnhController>/5
        [HttpPut("update-anh/{id}")]
        public bool Put(Guid id, ListAnh anhs)
        {
            var anh = _lstAnh.GetById(id);
            anh.Id = id;
            anh.Anh = anhs.Anh;
            anh.IdCtsp = anhs.IdCtsp;
            return _lstAnh.Update(anh);
        }

        // DELETE api/<LstAnhController>/5
        [HttpDelete("delete-anh/{id}")]
        public bool Delete(Guid id)
        {
            return _lstAnh.Delete(id);
        }
    }
}
