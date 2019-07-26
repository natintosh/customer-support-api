using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Models
{
    public class Complaint
    {
        [Required]
        public int Id { set; get; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(105)]
        public String CustomerName { set; get; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15)]
        public String PhoneNumber { set; get; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public String EmailAddress { set; get; }

        [Required(AllowEmptyStrings = false)]
        public String Description { set; get; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(12)]
        public String TicketNumber { set; get; }

        [Required(AllowEmptyStrings = false)]
        public int CompanyUnit { set; get; }

        [Required]
        public Boolean Resolved { set; get; }
    }
}
