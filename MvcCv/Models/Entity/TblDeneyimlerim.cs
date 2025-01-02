using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{

    public class TblDeneyimlerim
    {
        public int ID { get; set; }    

        [StringLength(100)]
        public string Baslik { get; set; }    

        [StringLength(100)]
        public string AltBaslik { get; set; }    

        public string Aciklama { get; set; }    

        [StringLength(100)]
        public string Tarih { get; set; }    
    }

}
