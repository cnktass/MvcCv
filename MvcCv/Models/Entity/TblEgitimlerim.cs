using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{

    public class TblEgitimlerim
    {
        
        public int ID { get; set; }    

        [StringLength(100)]
        public string Baslik { get; set; }

        [StringLength(100)]
        public string AltBaslik1 { get; set; }

        [StringLength(100)]
        public string AltBaslik2 { get; set; }

        [StringLength(50)]
        public string GNO { get; set; }

        [StringLength(100)]
        public string Tarih { get; set; }
    }

}
