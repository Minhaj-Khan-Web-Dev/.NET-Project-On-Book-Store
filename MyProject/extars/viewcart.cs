using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MyProject.extars
{
    public class viewcart
    {
        public int pid
        {
            get; set;
        }
        public string pname
        {
            get; set;
        }
        public string pimage
        {
            get; set;
        }
        public int qty
        {
            get; set;
        }

        public  int uprice
        {
            get; set;
        }

        public string totalprice
        {
            get; set;
        }
    }
}