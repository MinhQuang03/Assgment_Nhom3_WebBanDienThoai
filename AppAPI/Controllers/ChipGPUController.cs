using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipGPUController : ControllerBase
    {
        public IChipGPUServices chipGPUServices;
        public ChipGPUController()
        {
            chipGPUServices = new ChipGPUServices();
        }
        [HttpGet("get-all-Chip")]
        public List<ChipGPU> Get()
        {
            return chipGPUServices.GetAll();
        }

        // GET api/<ChipCPUController>/5
        [HttpGet("{id}")]
        public ChipGPU GetByID(Guid id)
        {
<<<<<<< Updated upstream
            return chipGPUServices.GetChipGPUById(id);
=======
            return chipGPUServices.GetChipGPUsById(id);
>>>>>>> Stashed changes
        }

        // POST api/<ChipCPUController>
        [HttpPost("create-chip")]
        public bool Create(ChipGPU chipGPU)
        {
            ChipGPU a = new ChipGPU()
            {
                Id = Guid.NewGuid(),
                Ten = chipGPU.Ten,
            };
            return chipGPUServices.Create(a);
        }

        // PUT api/<ChipCPUController>/5
        [HttpPut("update-chip-{id}")]
<<<<<<< Updated upstream
        public bool update(Guid id, ChipGPU chipGPU)
=======
        public bool update(Guid id, ChipGPU gpu)
>>>>>>> Stashed changes
        {
            ChipGPU a = new ChipGPU()
            {
                Id = id,
<<<<<<< Updated upstream
                Ten = chipGPU.Ten,
=======
                Ten = gpu.Ten,
>>>>>>> Stashed changes
            };
            return chipGPUServices.Update(a);
        }

        // DELETE api/<ChipCPUController>/5
        [HttpDelete("delete-chip-{id}")]
        public bool Delete(Guid id)
        {
            return chipGPUServices.Delete(id);
        }
    }
}
