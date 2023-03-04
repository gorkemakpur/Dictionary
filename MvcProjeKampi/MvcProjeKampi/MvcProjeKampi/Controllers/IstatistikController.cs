using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();

        public ActionResult Index()
        {

            var result1 = c.Categories.Count();
            var result2 = c.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            var result3 = c.Writers.Count(x => x.WriterName.Contains("a"));
            
            
            var result4 = c.Categories.Where(p => p.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                  .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();

            var result5 = c.Categories.Count(x => x.CategoryStatus == true);
            var result6 = c.Categories.Count(x => x.CategoryStatus == false);
            var result7 = result5 - result6;

            ViewBag.result1=result1;
            ViewBag.result2=result2;
            ViewBag.result3=result3;    
            ViewBag.result4=result4;    
            ViewBag.result5=result5;   
            ViewBag.result6=result6;
            ViewBag.result7 = result7;
            return View();
        }
    }
}