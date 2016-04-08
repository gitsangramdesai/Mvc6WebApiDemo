using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IContactsRepository: IDisposable
    {
        void Add(Contact item);
        IEnumerable<Contact> GetAll();
        Contact FindById(Guid key);
        void Remove(Contact item);
        void Update(Contact item);
    }
}
