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
            string p = (string)Session["WriterMail"];
            var countContact = cm.GetList().Count();
            var adminReceiver = mm.GetListInbox(p).Count();
            var adminSender = mm.GetListSendbox(p).Count();
            var readedMessage = mm.MessageIsRead().Count();
            var unReadedMessage = mm.MessageUnRead().Count();
            var draftMessage = mm.DraftMessages().Count();
            var thrashMessage = mm.TrashMessage().Count();

            ViewBag.unReadedMessage = unReadedMessage;
            ViewBag.ContactCount = countContact;
            ViewBag.AdminReceiver= adminReceiver;
            ViewBag.AdminSender= adminSender;
            ViewBag.readedMessage = readedMessage;
            ViewBag.draftMessage = draftMessage;
            ViewBag.thrashMessage = thrashMessage;

            return PartialView();
        }



    }
}