using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    public class NhaSanXuatController : Controller
    {
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            ViewBag.Domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/GiamGia/get-all-MaGiamGia");
            List<NhaSanXuat> nhaSanXuat = JsonConvert.DeserializeObject<List<NhaSanXuat>>(datajson);
            return View(nhaSanXuat);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NhaSanXuat nsx)
        {

            return View();
        }
    }
}
