using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTutorial.Models
{
    public class Inventory
    {
        [Key]
        public int I_ID { get; set; }

        [ForeignKey("Product")]
        public int I_PID { get; set; }

        //public int I_Price { get; set; }

        public int I_Amount { get; set; }

        public bool I_Status { get; set; }
        //Diff types of status:
        //In stock, Need to reorder (trigger), Out of Stock
    }
}
