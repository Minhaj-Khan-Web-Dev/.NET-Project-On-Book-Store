using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.extars
{
    public class prdt
    {
        public int id
        {
            get; set;
        }

        public string prdtname
        {
            get; set;
        }

        public int qty
        {
            get; set;
        }

        public string pricexqty
        {
            get; set;
        }
    }
    public class cnfrmorder
    {
        public IEnumerable<prdt> products
        {
            get; set;
        }
        public string totalAmount
        {
            get; set;
        }
    }
}