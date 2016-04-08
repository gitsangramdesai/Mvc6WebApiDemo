using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.EFRepositoy
{
    public class ApplicationContext : DbContext
    {
        private static bool _created = false;
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Call> Calls { get; set; }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : ModelBase
        {
            return base.Set<TEntity>();
        }
        public ApplicationContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().HasKey(b => b.ID);
            builder.Entity<Call>().HasKey(b => b.ID);
            base.OnModelCreating(builder);
        }
    }
}
