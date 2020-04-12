using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesTutorial.Models
{
    public class Product
    {
        public enum Product_Category
        {
            Cat1, Cat2, Cate3, Cat4, Cat5
        }
        [Key]
        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public string P_Category { get; set; }
        public string? P_Image { get; set; }
        public int? P_Price { get; set; }
        public string? P_Description { get; set; }
        public int? P_Amount { get; set; }

        //public bool P_Status{ get; set; }

    }
}
