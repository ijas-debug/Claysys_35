using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FinalProject.Models
{
    public class VisaStatus
    {
        [Required(ErrorMessage = "Enter Email Id!")]
        [Display(Name = "Email id:")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address format.")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Enter Passport Number!")]
        [Display(Name = "Passport number:")]
        public string PassportNumber { get; set; }
    }
}