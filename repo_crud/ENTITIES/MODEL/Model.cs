using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ENTITIES.MODEL
{
    public  class regiter
    {
        [Key]
        public  int R_ID { get; set; }
        public string NAME { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int PH_number { get; set; }
        // public Regiter_STUD E_ID { get; set; }

    }
    public class Regiter_STUD
    {
        [Key]
      
       public int stud_ID { get; set; }
        public string? E_ID { get; set; }
        public int R_ID { get; set;}
        public string Gender { get; set; }
    }

}
