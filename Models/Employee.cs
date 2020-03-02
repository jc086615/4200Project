using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _4200Project.Models
{
    public class Employee
    {
        [Key]
        public System.Guid EID { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Employee first name is required")]
        [StringLength(20)]

        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Employee last name is required")]
        [StringLength(20)]

        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone number must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Email address is required")]

        public string Email { get; set; }

        [Display(Name = "Home Office")]
        [Required(ErrorMessage = "Home office is required")]
        [StringLength(20)]

        public string HomeOffice { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit is required")]
        [StringLength(50)]

        public string BusinessUnit { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]

        public string Title { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "Hire Date is required")]

        public string HireDate { get; set; }


        
        
       
    }
}