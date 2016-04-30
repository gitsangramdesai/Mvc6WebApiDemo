using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.EFRepositoy;
using Microsoft.Data.Entity;

namespace WebApplication1.Repository
{
    public class ContactsRepository : Repository<Contact>,IRepository.IContactsRepository, IDisposable
    {
        public ContactsRepository(ApplicationContext dbContext)
        {
            base.DbContext = dbContext;
        }
        public override Contact  Add(Contact item)
        {
            if (item != null) {
                item.AddedDate = DateTime.Now;
                base.DbSet.Add(item);
                base.SaveChanges();
                return item;
            }
            else
            {
                throw new ArgumentNullException("items can't be null");
            }
        }
        public override Contact[] Add(Contact[] items)
        {
            if(items != null)
            {
                foreach (var item in items)
                {
                    item.AddedDate = DateTime.Now;
                    base.DbSet.Add(item);
                }
                base.SaveChanges();
                return items;
            }else
            {
                throw new ArgumentNullException("items can't be null");
            }
          
        }

        public override Contact FindById(Guid key)
        {
            return base.DbSet
                .Where(e => e.ID.Equals(key))
                .SingleOrDefault();
        }
        public override Contact[] FindById(Guid[] keys)
        {
            return base.DbSet.Where(e => keys.Contains(e.ID)).ToArray();
        }

        public override IEnumerable<Contact> GetAll()
        {
            return base.DbSet;
        }
        public override void Remove(Contact contact)
        {
            var itemToRemove = base.DbSet.SingleOrDefault(r => r.Email == contact.Email);
            if (itemToRemove != null)
            {
                base.DbSet.Remove(itemToRemove);
                base.SaveChanges();
            }
        }
        public override Contact Update(Contact item)
        {
            var itemToUpdate = base.DbSet.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
                itemToUpdate.ModifiedDate = DateTime.Now;
                base.DbSet.Update(itemToUpdate);
                base.SaveChanges();
                return itemToUpdate;
            }else
            {
                throw new ArgumentNullException("Item can't me null");
            }
          
        }
    }
}
