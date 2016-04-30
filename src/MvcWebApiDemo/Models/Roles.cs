using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
        public static class Roles
        {
            public static Role Student = new Role("student", "Student");
            public static Role Author = new Role("author", "Author");
            public static Role Reviewer = new Role("reviewer", "Reviewer");
            public static Role Administrator = new Role("admin", "Administrator");
        }

        public class Role
        {
            public Role(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public string Id { get; }

            public string Name { get; }
        }
}
