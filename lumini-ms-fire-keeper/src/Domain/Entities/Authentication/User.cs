using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lumini.FireKeeper.Domain.Entities.Authentication
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Document { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
