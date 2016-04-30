using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface IRepository
    {

    }
    public interface IRepositoryBase<TEnt, in TPk> : IDisposable,IRepository  where TEnt: ModelWithTracking
    {
        IEnumerable<TEnt> GetAll();

        TEnt FindById(TPk id);
        TEnt[] FindById(Guid[] ids);

        void Remove(TEnt entity);
        void Remove(TEnt[] entities);
        void Remove(TPk id);
        void Remove(TPk[] ids);

        TEnt Update(TEnt entity);

        TEnt Add(TEnt entity);
        TEnt[] Add(TEnt[] values);
    }
}
