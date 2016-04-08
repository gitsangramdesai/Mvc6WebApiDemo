using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.EFRepositoy;
using WebApplication1.Repository;

namespace WebApplication1.UnitOfWork
{
    public class UnitOfWork
    {
        private bool disposed = false;
        private ApplicationContext context = new ApplicationContext();

        private Repository<Call> callRepository;
        private Repository<Contact> contactRepository;

        public Repository<Call> CallRepository
        {
            get
            {
                if (this.callRepository == null)
                {
                    this.callRepository = new Repository<Call>(context);
                }
                return callRepository;
            }
        }
        public Repository<Contact> ContactRepository
        {
            get
            {
                if (this.contactRepository == null)
                {
                    this.contactRepository = new Repository<Contact>(context);
                }
                return contactRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
