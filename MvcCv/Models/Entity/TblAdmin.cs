using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{
    public class TblAdmin
    {
        public int ID { get; set; }
        [StringLength(50)] 
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }
    }
}
