using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageFileManager im = new ImageFileManager(new EfImageFileDal());
        Context c = new Context();
        public ActionResult Index()
        {
            var values = im.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ImagePath = "/Images/" + fileName;
                im.AddImage(p);
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}