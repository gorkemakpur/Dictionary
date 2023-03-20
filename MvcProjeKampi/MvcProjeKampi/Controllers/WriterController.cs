using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
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

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            p.WriterPassword = Sha512(p.WriterPassword);
                
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }



    }
}