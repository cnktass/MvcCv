using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{

    public class TblIletisim
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string AdSoyad { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [StringLength(100)]
        public string Konu { get; set; }

        [StringLength(2000)]
        public string Mesaj { get; set; }

        public DateTime? Tarih { get; set; }

    }
}