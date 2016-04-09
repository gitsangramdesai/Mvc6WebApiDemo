using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.AppConfig;
using Microsoft.Extensions.OptionsModel;

namespace WebApplication1.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly UnitOfWork.UnitOfWork UnitOfWork = new UnitOfWork.UnitOfWork();
        protected readonly ILogger Logger;
        protected readonly AppSettings AppSettings;

        public ControllerBase(ILogger<ControllerBase> logger, IOptions<AppSettings> appSettings)
        {
            Logger = logger;
            AppSettings = appSettings.Value;
        }

        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
