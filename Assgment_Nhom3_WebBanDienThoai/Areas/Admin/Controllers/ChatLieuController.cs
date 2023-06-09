using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChatLieuController
    {
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        //public async Task<IActionResult> Index()
        //{
        //    ViewBag.Domain = domain;
        //    client.BaseAddress = new Uri(domain);
        //    string datajson = await client.GetStringAsync("api/GiamGia/get-all-MaGiamGia");
        //    List<GiamGia> giamGias = JsonConvert.DeserializeObject<List<GiamGia>>(datajson);
        //    return View(giamGias);
        //}
    }
}
