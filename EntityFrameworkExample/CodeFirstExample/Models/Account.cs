using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Models
{
    [Table("Account", Schema = "Bank")]
    public class Account
    {
        public Account()
        {
            this.Users = new HashSet<User>();
        }
        public int AccountId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public virtual ICollection<User> Users { get; set; }

    }
}
