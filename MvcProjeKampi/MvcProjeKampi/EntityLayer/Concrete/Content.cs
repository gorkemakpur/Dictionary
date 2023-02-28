using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(2500)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }


        //ContentBaşlık içerik hangi başlığa yazıldı
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }


        //ContentYazar içeriği kim yazdı soru işareti eklendiğinde nullable type oluyor
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
