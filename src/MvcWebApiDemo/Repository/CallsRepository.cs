using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.EFRepositoy;
using Microsoft.Data.Entity;

namespace WebApplication1.Repository
{
    public class CallsRepository : Repository<Call>, ICallRepository, IDisposable
    {
        public CallsRepository(ApplicationContext dbContext)
        {
            base.DbContext = dbContext;
        }
    }
}
