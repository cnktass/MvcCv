using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{

    public class TblHobilerim
    {
        [Key]
        public int ID { get; set; }    

        [StringLength(100)]
        public string Aciklama1 { get; set; }   

        [StringLength(100)]
        public string Aciklama2 { get; set; }    
    }

}
