using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMebyas.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }

        [Required]
        public string Company { get; set; }

        [Required(), DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
        public string Email { get; set; }

        public string Address { get; set; }

        [DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public long Phone { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}