using Microsoft.AspNetCore.Mvc;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImeiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
