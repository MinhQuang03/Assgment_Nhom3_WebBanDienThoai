using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            ViewBag.Domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/SanPham/get-all-sanpham");
            List<SanPham> sp = JsonConvert.DeserializeObject<List<SanPham>>(datajson);
            return View(sp);
        }

        public async Task<IActionResult> Create()
        {
            client.BaseAddress = new Uri(domain);
            string nhaSanXuat = await client.GetStringAsync("api/NhaSanXuat/get-all-nhasanxuat");
            List<NhaSanXuat> nsx = JsonConvert.DeserializeObject<List<NhaSanXuat>>(nhaSanXuat);
            ViewBag.IdHsx = new SelectList(nsx, "Id", "Ten");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SanPham sp)
        {
            var requestUrl = "https://localhost:7151/api/SanPham/create-SanPham-img";
            if (await _apiService.ApiPostService(sp, requestUrl))
                return RedirectToAction("Index");
            else return View();
        }
    }
}
