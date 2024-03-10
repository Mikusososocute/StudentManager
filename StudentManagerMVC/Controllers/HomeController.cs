using Microsoft.AspNetCore.Mvc;
using StudentManagerMVC.Models;
using System.Diagnostics;
using StudentManagerBLL;

namespace StudentManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStuInfoBLL _stuInfoBLL;

        public HomeController(ILogger<HomeController> logger, IStuInfoBLL stuInfoBLL)
        {
            _logger = logger;
            _stuInfoBLL = stuInfoBLL;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ÐÂÔöÒ³
        /// </summary>
        /// <returns></returns>
        public IActionResult AddDialog()
        {
            return View();
        }

        /// <summary>
        /// ±à¼­Ò³
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DataEditDialog(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
