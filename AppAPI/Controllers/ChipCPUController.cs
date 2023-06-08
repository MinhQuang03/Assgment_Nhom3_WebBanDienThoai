using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipCPUController : ControllerBase
    {
        public IChipCPUServices chipCPUServices;
        public ChipCPUController()
        {
            chipCPUServices = new ChipCPUServices();
        }
        // GET: api/<ChipCPUController>
        [HttpGet("get-all-Chip")]
        public List<ChipCPU> Get()
        {
            return chipCPUServices.GetAll();
        }

        // GET api/<ChipCPUController>/5
        [HttpGet("{id}")]
        public ChipCPU GetByID(Guid id)
        {
            return chipCPUServices.GetChipCPUById(id);
        }

        // POST api/<ChipCPUController>
        [HttpPost("create-chip")]
        public bool Create(ChipCPU chipCPU)
        {
            ChipCPU a = new ChipCPU()
            {
                Id = Guid.NewGuid(),
                Ten = chipCPU.Ten,
            };
            return chipCPUServices.Create(a);
        }

        // PUT api/<ChipCPUController>/5
        [HttpPut("update-chip-{id}")]
        public bool update(Guid id, ChipCPU chipCPU)
        {
            ChipCPU a = new ChipCPU()
            {
                Id = id,
                Ten = chipCPU.Ten,
            };
            return chipCPUServices.Update(a);
        }

        // DELETE api/<ChipCPUController>/5
        [HttpDelete("delete-chip-{id}")]
        public bool Delete(Guid id)
        {
            return chipCPUServices.Delete(id);
        }
    }
}
