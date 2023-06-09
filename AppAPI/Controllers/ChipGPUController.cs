using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

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
        return chipGPUServices.GetChipGPUById(id);
    }

    // POST api/<ChipCPUController>
    [HttpPost("create-chip")]
    public bool Create(ChipGPU chipGPU)
    {
        var a = new ChipGPU()
        {
            Id = Guid.NewGuid(),
            Ten = chipGPU.Ten,
        };
        return chipGPUServices.Create(a);
    }

    // PUT api/<ChipCPUController>/5
    [HttpPut("update-chip-{id}")]
    public bool update(Guid id, ChipGPU chipGPU)
    {
        var a = new ChipGPU()
        {
            Id = id,
            Ten = chipGPU.Ten,
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