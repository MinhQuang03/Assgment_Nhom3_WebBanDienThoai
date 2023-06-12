using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers;

public class HomeController : Controller
{
    private ApiService _apiService = new();
    string domain = "https://localhost:7151/";
    HttpClient client = new HttpClient();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        string datajson = await client.GetStringAsync("api/ChiTietSanPham/get-all-thongTin-SanPham");
        List<ChiTietSanPham> ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(datajson);
        return View(ctsp);
    }

    public async Task<IActionResult> PhoneDetail(Guid id)
    {
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/ChiTietSanPham/{id}");
        var ctsp = JsonConvert.DeserializeObject<ChiTietSanPham>(datajson);
        return View(ctsp);
    }

    public async Task<IActionResult> ShowPhone()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        string datajson = await client.GetStringAsync("api/ChiTietSanPham/get-all-thongTin-SanPham");
        List<ChiTietSanPham> ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(datajson);
        return View(ctsp);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}