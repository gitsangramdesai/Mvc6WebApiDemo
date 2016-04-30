using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public string DeviceId { get; set; }

         public virtual List<UserProfilePicture> UserProfilePictures { get; set; }
    }

    [Table("UserProfilePicture")]
    public class UserProfilePicture
    {
        public byte ImageType { get; set; }
        public Byte[] Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        [Column("UserId")]
        [ForeignKey("ApplicationUser")]
        public virtual int UserId { get; set; }

       
        public ApplicationUser ApplicationUser { get; set; }
    }
}
