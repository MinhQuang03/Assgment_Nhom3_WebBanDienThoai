using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GiamGiaController : Controller
    {
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            ViewBag.Domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/GiamGia/get-all-MaGiamGia");
            List<GiamGia> giamGias = JsonConvert.DeserializeObject<List<GiamGia>>(datajson);
            return View(giamGias);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiamGia gg)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(gg);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:7151/api/GiamGia/create-MaGiamGia", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Them thanh cong";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            GiamGia gg = new GiamGia();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7151/api/GiamGia/Get" + id);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                gg = JsonConvert.DeserializeObject<GiamGia>(data);
            }
            return View(gg);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(GiamGia gg)
        {
            string data = JsonConvert.SerializeObject(gg);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:7151/api/GiamGia/update", content);
            if (response.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
