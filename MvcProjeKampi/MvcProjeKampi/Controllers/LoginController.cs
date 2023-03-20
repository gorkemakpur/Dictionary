using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
//using static System.Console;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        AdminLoginManager alm = new AdminLoginManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Admin p)
        {
            p.AdminPassword = Sha512(p.AdminPassword);
            var adminUserInfo = alm.GetAdmin(p.AdminUserName, p.AdminPassword);

            if (adminUserInfo != null)
            {

                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Hata = "Hata";
                return RedirectToAction("Index");
            }
        }



        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            p.WriterPassword = Sha512(p.WriterPassword);
            var writerUserInfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);


            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.Mesaj = "Hatalı Giriş Yaptınız Lütfen Tekrar Deneyiniz";
                return View("WriterLogin");
            }

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


        //string HashPassword(string password)
        //{
        //    SHA256 hash = SHA256.Create();
        //    var passwordBytes = Encoding.Default.GetBytes(password);
        //    var hashedPassword= hash.ComputeHash(passwordBytes);
        //    return Convert.ToHexString(hashedPassword);

        //}


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}