using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebApplication1.Controllers
{
    public class ControllerBase : Controller
    {
        protected UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
