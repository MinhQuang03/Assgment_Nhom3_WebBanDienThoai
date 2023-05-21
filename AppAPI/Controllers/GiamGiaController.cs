using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        public readonly ISimServices simServices;
        public GiamGiaController()
        {
            simServices = new SimServices();
        }

        // GET: api/<GiamGiaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GiamGiaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GiamGiaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GiamGiaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GiamGiaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
