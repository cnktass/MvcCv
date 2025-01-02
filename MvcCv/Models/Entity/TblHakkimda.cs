using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{

    public class TblHakkimda
    {
      
        public int ID { get; set; }    

        [StringLength(100)]
        public string Baslik { get; set; }    

        [StringLength(100)]
        public string AltBaslik { get; set; }    

        public string Aciklama { get; set; }   

        [StringLength(100)]
        public string Tarih { get; set; }
        public string Resim { get; set; }
    }

}
