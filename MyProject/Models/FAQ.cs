using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyProject.Models
{
    public class FAQ
    {
        [Key]
        public int f_id { get; set; }
        public string Name { get; set; }
        public string f_qus { get; set; }
       
        public string  f_ans { get; set; }

    }
}