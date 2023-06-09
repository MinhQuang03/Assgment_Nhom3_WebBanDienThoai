﻿using Assgment_Nhom3_WebBanDienThoai.IServices;
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
        [HttpGet("get-all-ChipGPU")]
        public List<ChipGPU> Get()
        {
            return chipGPUServices.GetAll();
        }

        // GET api/<ChipCPUController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChipCPUController>
        [HttpPost("create-chip")]
        public bool Create(string ten)
        {
            ChipGPU a = new ChipGPU()
            {
                Id = Guid.NewGuid(),
                Ten = ten,
            };
            return chipGPUServices.Create(a);
        }

        // PUT api/<ChipCPUController>/5
        [HttpPut("update-chip-{id}")]
        public bool update(Guid id, [FromBody] string ten)
        {
            ChipGPU a = new ChipGPU()
            {
                Id = id,
                Ten = ten,
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
