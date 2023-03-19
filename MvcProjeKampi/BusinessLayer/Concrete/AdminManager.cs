using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void AdminDelete(Admin admin)
        {
            if (admin.AdminStatus == true) { admin.AdminStatus = false; }
            else if (admin.AdminStatus == false) { admin.AdminStatus = true; }
            _adminDal.Update(admin);

        }


        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetByAdminID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
