using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        AdminRoleManager arm = new AdminRoleManager(new EfAdminRoleDal());
        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            return View(adminValues);
        }

        public ActionResult AdminDelete(int id)
        {
            var adminValue = adm.GetByAdminID(id);
            adm.AdminDelete(adminValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueAdminRole = (from x in arm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.AdminRoleType,
                                                       Value = x.AdminRoleID.ToString()
                                                   }).ToList();


            ViewBag.valueAdminRole = valueAdminRole;

            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            p.AdminStatus = true;
            p.AdminPassword = Sha512(p.AdminPassword);
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueAdminRole = (from x in arm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AdminRoleType,
                                                    Value = x.AdminRoleID.ToString()
                                                }).ToList();


            ViewBag.valueAdminRole = valueAdminRole;




            var adminValue = adm.GetByAdminID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            //p.AdminPassword = Sha512(p.AdminPassword);
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }


        private string Sha512(string text)
        {
            SHA512 sha512Encrypting = new SHA512CryptoServiceProvider();
            byte[] bytes = sha512Encrypting.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder builder = new StringBuilder();

            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();

        }


    }
}