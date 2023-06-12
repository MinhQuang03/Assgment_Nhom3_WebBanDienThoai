using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers
{
    public class LoginController : Controller
    {
        ShoppingDbContext shopingBDContext = new ShoppingDbContext();
        private readonly ILogger<GioHangController> _logger;
        private readonly IChiTietSanPhamServices _sanphamServices;
        private readonly ITaiKhoanServices _tkServices;
        private readonly IGioHangServices _cartServices;
        private readonly IGioHangChiTietServices _cartDetailService;
        private readonly IPhanQuyenServices _roleServices;


        public LoginController(ILogger<GioHangController> logger)
        {
            _logger = logger;
            _sanphamServices = new ChiTietSanPhamServices();
            _tkServices = new TaiKhoanServices();
            _cartServices = new GioHangServices();
            _cartDetailService = new GioHangChiTietServices();
            _roleServices = new PhanQuyenServices();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Show
        public ActionResult Show(int id)
        {
            var User = shopingBDContext.TaiKhoans.Include("Role").ToList();
            return View(User);
        }

        // GET: LoginController/Detail
        public ActionResult Detail(Guid id)
        {
            var User = shopingBDContext.TaiKhoans.Find(id);
            return View(User);
        }
        // GET: LoginController/Create
        //public ActionResult Login()
        //      {
        //          return View();
        //      }
        //[HttpPost]
        public ActionResult Login(string username, string password)
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Index");
            if (ModelState.IsValid)
            {
                var data = shopingBDContext.TaiKhoans.Include("Roles").FirstOrDefault(p => p.TenDN.Equals(username) && p.MatKhau.Equals(password));
                if (data != null)
                {
                    //add Session
                    HttpContext.Session.SetString("acc", data.TenDN);
                    HttpContext.Session.SetString("role", data.PhanQuyens.TenQuyen);
                    var acc = HttpContext.Session.GetString("acc");
                    var x = _tkServices.GetAll().FirstOrDefault(x => x.TenDN == username);
                    var lstCart = _cartServices.GetAll();
                    var cartDetails = _cartDetailService.GetAll().Where(c => c.IdTaiKhoan == x.Id).ToList();
                    HttpContext.Session.SetString("CartDetailsUser", cartDetails.Count().ToString());
                    if (lstCart.FirstOrDefault(c => c.IdTaiKhoan == x.Id) == null)
                    {
                        GioHang cart = new GioHang()
                        {
                            IdTaiKhoan = x.Id,
                            Mota = null,
                        };
                        _cartServices.Create(cart);
                    }
                    HttpContext.Session.Remove("Cart");
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }
        public ActionResult Create(int id)
        {
            ViewBag.Role = new SelectList(_roleServices.GetAllQuyens(), "Id", "RoleName");
            return View();
        }
        // POST: LoginController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(TaiKhoan User, IFormFile imageFile)
        {
            
            if (_tkServices.CreateTaiKhoan(User))
            {
                GioHang cart = new GioHang()
                {
                    IdTaiKhoan = User.Id,
                    Mota = "Than Thiet"
                };
                _cartServices.Create(cart);
                return RedirectToAction("Login");
            }
            else return BadRequest();
        }
        [HttpGet]

        // GET: LoginController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Role = new SelectList(_roleServices.GetAllQuyens(), "Id", "RoleName");
            TaiKhoan User = _tkServices.GetSanPhamById(id);
            return View(User);
        }

        // POST: LoginController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(TaiKhoan user)
        {
            ViewBag.Role = new SelectList(_roleServices.GetAllQuyens(), "Id", "RoleName");
            if (_tkServices.UpdateTaiKhoan(user))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }




        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
