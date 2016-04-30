﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface IContactsRepository: IDisposable, IRepositoryBase<Models.Contact,Guid>
    {

    }
}
