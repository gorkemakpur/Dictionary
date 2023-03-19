using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }


        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }


        public List<HeadingModels> HeadingList()
        {
            List<HeadingModels> headingClasses = new List<HeadingModels>();




            var values = hm.GetList();
            var counter = 0;
            foreach (var item in values)
            {
                var values2 = cm.GetListByHeadingID(item.HeadingID);
                foreach (var item2 in values2)
                {
                    counter = counter + 1;
                }
                headingClasses.Add(new HeadingModels()
                {
                    HeadingName = item.HeadingName,
                    HeadingCount = counter
                });
                counter = 0;
            }


            return headingClasses;





        }


        public List<CategoryModels> BlogList()
        {
            List<CategoryModels> categoryClasses = new List<CategoryModels>();

            categoryClasses.Add(new CategoryModels()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });

            categoryClasses.Add(new CategoryModels()
            {
                CategoryName = "Seyahat",
                CategoryCount = 12
            });

            categoryClasses.Add(new CategoryModels()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 6
            });

            categoryClasses.Add(new CategoryModels()
            {
                CategoryName = "Spor",
                CategoryCount = 3
            });
            return categoryClasses;
        }
    }
}