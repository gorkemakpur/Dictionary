using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            _messageDal.Add(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }
        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> MessageIsRead()
        {
            return _messageDal.List(x => x.IsRead == true);
        }
        public List<Message> MessageUnRead()
        {
            return _messageDal.List(x => x.IsRead == false && x.SenderMail!="admin@gmail.com");
        }

        public void DraftAdd(Message message)
        {
            message.IsDraft = true;
        }
        public List<Message> DraftMessages()
        {
            return _messageDal.List(x => x.IsDraft == true);
        }

        public void TrashAdd(Message message)
        {
            message.Trash = true;
        }

        public List<Message> TrashMessage()
        {
            return _messageDal.List(x => x.Trash == true);
        }

        //bu kısıma bidaha bakıcam
        public void MessageReadStatusChange(Message message)
        {
            if (message.IsRead == true) { message.IsRead = false; }
            else { message.IsRead = true; }
            _messageDal.Update(message);
               
        }
    }
}
