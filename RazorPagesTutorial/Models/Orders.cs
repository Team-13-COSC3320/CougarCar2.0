using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesTutorial.Models
{
    public class Orders
    {
        [Key]
        public Int32 O_ID { get; set; }
        public DateTime? O_Date { get; set; }

        [ForeignKey("Product")]
        public Int32? O_UID { get; set; }
        public Int32? O_PIDS { get; set; }
        //public Int32? O_Amount { get; set; } don't need order amount anymore either
        //since no shopping cart, people will only buy one at a time
        public String O_Status { get; set; } //Processing, and Ready

    }
}
