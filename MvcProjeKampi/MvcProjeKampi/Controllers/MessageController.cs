using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageValues = mm.GetListInbox(p);
            return View(messageValues);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageValues = mm.GetListSendbox(p);
            return View(messageValues);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }




        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);

            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.AddMessage(p);

                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        public ActionResult MessageIsRead()
        {
            var values = mm.MessageIsRead();
            return View(values);
        }

        public ActionResult MessageReadStatus(Message p)
        {
            mm.MessageReadStatusChange(p);
            return RedirectToAction("Index");
        }

        public ActionResult MessageUnReaded()
        {
            var values = mm.MessageUnRead();
            return View(values);
        }


        public ActionResult Draft()
        {
            var values = mm.DraftMessages();
            return View(values);
        }
        public ActionResult MessageDraft(Message p)
        {
            mm.DraftAdd(p);
            mm.AddMessage(p);
            return View();
        }

        public ActionResult Trash()
        {
            var values = mm.TrashMessage();
            return View(values);
        }
        public ActionResult MessageTrash(Message p)
        {
            mm.TrashAdd(p);
            return View();
        }










        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }


    }
}