using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(350)]
        public string AdminPassword { get; set; }


        public bool AdminStatus { get; set; }


        public int AdminRoleID { get; set; }
        public virtual AdminRole AdminRole { get; set; }

    }
}
