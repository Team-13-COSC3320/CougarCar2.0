using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTutorial.Models
{
    public class LoginUSER
    {
        [Key]
        [Display(Name = "ID")]
        public int U_ID { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string U_Pass { get; set; }


        [Display(Name = "Last name")]
        public string U_LName { get; set; }

        
        [Display(Name = "Role")]
        public string U_Role { get; set; }
    }
}
