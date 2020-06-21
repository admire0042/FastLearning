using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearning.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name between 2 to 20 characters")]
        [StringLength(20, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter a valid name between 2 to 50 characters")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name ="Other Names")]
        public string Othernames { get; set; }

        [Required(ErrorMessage = "Pls Enter a Vailid Number xxx-xxx-xxxx")]
        [RegularExpression(@"[0]\d{10}$")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]

        public string Address { get; set; }

            [Required]
        public string City { get; set; }

        [Required]
        public string Age { get; set; }

        [Required(ErrorMessage = "Please enter your State of Origin")]
        [Display(Name = "State of Origin")]
        public string State { get; set; }


        [Required]

        public string Passport { get; set; }
    }
}
