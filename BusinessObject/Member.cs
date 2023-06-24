using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        [Required, StringLength(50)]
        public string? Email { get; set; }
        [Required, StringLength(50)]
        public string? CompanyName { get; set; }
        [Required, StringLength(20)]
        public string? city { get; set; }
        [Required, StringLength(20)]
        public string? country { get; set; }
        [Required, StringLength(20)]
        public string? passWord { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
