using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;

[Area("Admin")]
public class NhaSansXuatsController : Controller
{
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync("api/NhaSanXuat/get-all-nhasanxuat");
        var nhaSanXuat = JsonConvert.DeserializeObject<List<NhaSanXuat>>(datajson);
        return View(nhaSanXuat);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NhaSanXuat nsx)
    {
        var requestUrl = "https://localhost:7151/api/NhaSanXuat/create-nhasanxuat";
        if (await _apiService.ApiPostService(nsx, requestUrl)) return RedirectToAction("Index");
        return View();
    }
}