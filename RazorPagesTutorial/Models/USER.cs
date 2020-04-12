using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTutorial.Models
{
    public class USER
    {
        [Key]
        [Display(Name = "ID")]
        public int U_ID { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string U_Pass { get; set; }


        [Display(Name = "First name")]
        public string U_FName { get; set; }


        [Display(Name = "Last name")]
        public string U_LName { get; set; }



        [Display(Name = "Address")]
        public string U_Address { get; set; }



        [Display(Name = "Country")]
        public string U_Country { get; set; }



        [Display(Name = "Zip code")]
        public string U_Zipcode { get; set; }



        [Display(Name = "Phone")]
        public string U_Phone { get; set; }



        [Display(Name = "Email")]
        public string U_Email { get; set; }


        [Required]
        [Display(Name = "Role")]
        public string U_Role { get; set; }
    }
}
