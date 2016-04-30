using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Identity
    {
        public string UserId { get; set; }

        public string Role { get; set; }

        public bool IsAdmin()
        {
            return this.Role == Roles.Administrator.Id || this.Role == Roles.Administrator.Name;
        }
        public bool IsAuthor()
        {
            return this.Role == Roles.Author.Id || this.Role == Roles.Author.Name;
        }
        public bool IsReviewer()
        {
            return this.Role == Roles.Reviewer.Id || this.Role == Roles.Reviewer.Name;
        }
        public bool IsStudent()
        {
            return this.Role == Roles.Student.Id || this.Role == Roles.Student.Name;
        }
    }
}
