using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTutorial.Models
{
    public class Inventory
    {
        public int I_ID { get; set; }
        public int I_PID { get; set; }

        //public int I_Price { get; set; }

        public int I_Amount { get; set; }

        public bool I_Status { get; set; }
        //Diff types of status:
        //In stock, Need to reorder (trigger), Out of Stock
    }
}
