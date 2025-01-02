using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{


    public class TblYeteneklerim
    {
        public int ID { get; set; }    

        [StringLength(100)]
        public string Yetenek { get; set; }    
    }

}
