using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRMebyas.Models
{
    public class Note
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Body { get; set; }
        public DateTime DateEntered { get; set; }
        public string UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
}