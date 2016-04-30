using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.IDomain;
using WebApplication1.Repository;

namespace WebApplication1.Domain
{
    public class ContactDomain : ProcessBaseWithStorageOperations<WebApplication1.Repository.ContactsRepository, WebApplication1.Models.Contact>, WebApplication1.IDomain.IContactDomain
    {
        public ContactDomain(ContactsRepository repository) : base(repository)
        {

        }
    }
}
