using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstExample.Models
{
    [Table("User",Schema = "Bank")]
    public class User
    {
        public User()
        {
            this.Accounts = new HashSet<Account>();
        }
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SSN { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
