using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.IDomain
{
    public interface IContactDomain : OperationSet, OperationSetWithStorageOperations<WebApplication1.Models.Contact>
    {
    }
}
