using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserKey> Keys { get; set; }
    }

    public class UserKey
    {
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string Key { get; set; }

        public string DeviceID { get; set; }

        [Required]
        public DateTime ExpiredOn { get; set; }

        [Key]
        public string Id { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<UserKey> UserKeys { get; set; }

    }
}
