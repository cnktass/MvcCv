using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{
    public class TblSertifikalarim
    {
        [Key]
        public int ID { get; set; }    

        [StringLength(500)]
        public string Aciklama { get; set; }    
    }

}
