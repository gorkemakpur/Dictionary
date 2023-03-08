using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());


        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult PartialOptions()
        {
            var countContact = cm.GetList().Count();
            var adminReceiver = mm.GetListInbox().Count();
            var adminSender = mm.GetListSendbox().Count();

            ViewBag.ContactCount = countContact;
            ViewBag.AdminReceiver= adminReceiver;
            ViewBag.AdminSender= adminSender;

            return PartialView();
        }



    }
}