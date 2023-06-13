using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> 5f4c0b1a8e9867626a1c3a5422f0ad4e6e9ef053
using Newtonsoft.Json;
using System.Diagnostics;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers;

public class HomeController : Controller
{
    private ApiService _apiService = new();
    string domain = "https://localhost:7151/";
    HttpClient client = new HttpClient();
    ShoppingDbContext _context;
    private readonly ILogger<HomeController> _logger;
    ShoppingDbContext ShoppingDbContext;
    IGioHangChiTietServices GioHangChiTietServices;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
<<<<<<< HEAD
        ShoppingDbContext= new ShoppingDbContext();
        GioHangChiTietServices = new GioHangChiTietServices();
=======
        _context = new ShoppingDbContext();
>>>>>>> 5f4c0b1a8e9867626a1c3a5422f0ad4e6e9ef053
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

<<<<<<< HEAD
    public async Task<IActionResult> AddToCard(Guid id)
    {
        var check = GioHangChiTietServices.GetAll().FirstOrDefault(x => x.IdChiTietSp == id);
        if (check != null)
        {
            var gh = GioHangChiTietServices.GetAll().FirstOrDefault(x=>x.IdChiTietSp == id && x.IdTaiKhoan == Guid.Parse("098ed3bf-1551-4d1a-b384-5d03f2cb772a"));
            gh.SoLuong += 1;
            GioHangChiTietServices.Update(gh);
            return RedirectToAction("showcart");
        }
        else
        {
            GioHangChiTiet cartDetail = new GioHangChiTiet();
            cartDetail.Id = new Guid();
            cartDetail.IdChiTietSp = id;
            cartDetail.IdTaiKhoan = Guid.Parse("098ed3bf-1551-4d1a-b384-5d03f2cb772a");
            cartDetail.SoLuong = 1;
            cartDetail.TrangThai = 1;
            GioHangChiTietServices.Create(cartDetail);
            return RedirectToAction("showcart");
        }
       
    }
    

    public async Task<IActionResult> Deletecart(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/GioHangChiTiet/delete-GioHangChiTiet-{id}";
        await _apiService.ApiDeleteService(requestUrl);
        return RedirectToAction("showcart");
    }
    [HttpGet]
    public async Task<IActionResult> showcart()
    {
      
        client.BaseAddress = new Uri(domain);
        string datajson = await client.GetStringAsync("api/GioHangChiTiet/get-all-GioHangChiTiet");
        List<GioHangChiTiet> ghct = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(datajson);
      
        
        return View(ghct);
    }
=======
    public async Task<IActionResult> TimKiem(string searchString, string minPrice, string maxPrice)
    {
        var books = _context.ChiTietSanPhams.Select(b => b);
        var ten = _context.SanPhams.Select(b => b);

        if (!string.IsNullOrEmpty(searchString))
        {

            ten = ten.Where(b => b.TenSp.Contains(searchString));
        }

        if (!string.IsNullOrEmpty(minPrice))
        {
            var min = int.Parse(minPrice);
            books = books.Where(b => b.DonGia >= min);
        }

        if (!string.IsNullOrEmpty(maxPrice))
        {
            var max = int.Parse(maxPrice);
            books = books.Where(b => b.DonGia <= max);
        }

        return View(await books.ToListAsync());
    }


>>>>>>> 5f4c0b1a8e9867626a1c3a5422f0ad4e6e9ef053
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