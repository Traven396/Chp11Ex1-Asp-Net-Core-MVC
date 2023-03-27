using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext context;
        public ValidationController(TempManagerContext ctx) {
            context = ctx;
        }
        public JsonResult CheckDate(string date)
        {
            if(DateTime.TryParse(date, out DateTime result))
            {
                var dateSI = context.Temps.FirstOrDefault(c => c.Date == result);
                if(dateSI != null)
                {
                    string msg = "That date already exists";
                    return Json(msg);
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                return null;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
