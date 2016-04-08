using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class ControllerBase : Controller
    {
        protected UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        protected readonly ILogger _logger;

        public ControllerBase(ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
