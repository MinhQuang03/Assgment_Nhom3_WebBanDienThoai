using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;

[Area("Admin")]
public class ChipCPUController1 : Controller
{
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync("api/ChipCPU/get-all-Chip");
        var chipCPU = JsonConvert.DeserializeObject<List<ChipCPU>>(datajson);
        return View(chipCPU);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ChipCPU cpu)
    {
        var requestUrl = "https://localhost:7151/api/ChipCPU/create-chip";
        if (await _apiService.ApiPostService(cpu, requestUrl)) return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/ChipCPU/{id}");
        var chipCPU = JsonConvert.DeserializeObject<ChipCPU>(datajson);
        return View(chipCPU);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Guid id, ChipCPU cpu)
    {
        var requestUrl = $"https://localhost:7151/api/ChipCPU/update-chip-{id}";
        if (await _apiService.ApiPutService(cpu, requestUrl)) return RedirectToAction("Index");
        return View();
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/ChipCPU/delete-chip-{id}";
        await _apiService.ApiDeleteService(requestUrl);
        return RedirectToAction("Index");
    }
}