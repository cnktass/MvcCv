using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{

    public class TblHakkimda
    {
      
        public int ID { get; set; }    

        [StringLength(100)]
        public string Ad { get; set; }    

        [StringLength(100)]
        public string Soyad { get; set; }    

        public string Adres { get; set; }   

        [StringLength(100)]
        public string Telefon { get; set; }
        [StringLength(100)]
        public string Mail { get; set; }
        public string Aciklama { get; set; }

        public string Resim { get; set; }
    }

}
