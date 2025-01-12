using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Role_tbl
    {
        [Key]
        public int Role_id { get; set; }

        public string Role_Title { get; set; }
        [ForeignKey("Registers")]
        public int Register_id
        {
            get; set;
        }

        public virtual Register Registers
        {
            get; set;
        }
    }
}