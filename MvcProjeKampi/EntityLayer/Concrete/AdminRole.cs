using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminRole
    {
        [Key]
        public int AdminRoleID { get; set; }
        public string AdminRoleType { get; set; }



        //----------------------------------
        public ICollection<Admin> Admins { get; set; }
        //public ICollection<Admin> Admin { get; set; }
    }
}
