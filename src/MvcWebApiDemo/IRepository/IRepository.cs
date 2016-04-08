using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IRepository<TEnt, in TPk> : IDisposable  where TEnt:ModelBase
    {
        IEnumerable<TEnt> GetAll();
        TEnt FindById(TPk id);
        void Add(TEnt entity);
        void Remove(TEnt entity);
        void Update(TEnt entity);
    }
}
