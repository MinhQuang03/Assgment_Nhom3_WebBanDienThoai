using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacController : ControllerBase
    {

        private IMauSacServices mauSacServices;

        public MauSacController()
        {
            mauSacServices = new MauSacServices();
        }
        // GET: api/<MauSacController>
        [HttpGet("get-all-mausac")]
        public List<MauSac> Get()
        {
            return mauSacServices.GetAllMauSacs();
        }

        

        // GET api/<MauSacController>/5
        [HttpGet("{id}")]
        public MauSac GetByID(Guid id)
        {
            return mauSacServices.GetMauSacsById(id);
        }

        // POST api/<MauSacController>
        [HttpPost("create-mausac")]
        public bool CreateMauSac(MauSac msdt)
        {
            MauSac ms = new MauSac()
            {
                Id = Guid.NewGuid(),
                Ten = msdt.Ten,
            };
            return mauSacServices.CreateMauSac(ms);
        }

        // PUT api/<MauSacController>/5
        [HttpPut("update-mausac-{id}")]
<<<<<<< Updated upstream
        public bool UpdateMauSac(Guid id, MauSac msdt)
=======
        public bool UpdateMauSac(Guid id, MauSac mauSac)
>>>>>>> Stashed changes
        {
            MauSac ms = new MauSac()
            {
                Id = id,
<<<<<<< Updated upstream
                Ten = msdt.Ten,
=======
                Ten = mauSac.Ten,
>>>>>>> Stashed changes
            };
            return mauSacServices.UpdateMauSac(ms);
        }
     
        // DELETE api/<MauSacController>/5
        [HttpDelete("delete-mausac-{id}")]
        public bool Delete(Guid id)
        {
            return mauSacServices.DeleteMauSac(id);
        }
    }
}
