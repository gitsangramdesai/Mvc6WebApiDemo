using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;
using Microsoft.AspNet.Mvc;
using WebApplication1.UnitOfWork;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using WebApplication1.AppConfig;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class CallsController : ControllerBase
    {
        public CallsController(ILogger<ControllerBase> logger, IOptions<AppSettings> appSettings) :base(logger, appSettings)
        {

        }

        [HttpPost]
        public IActionResult Create([FromBody] Call item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            UnitOfWork.CallRepository.Add(item);
            return CreatedAtRoute("GetCalls", new { Controller = "Calls", id = item.ID }, item);
        }
        [HttpGet("{id}", Name = "GetCalls")]
        public IActionResult GetById(Guid id)
        {
            System.Diagnostics.Debugger.Break();
            var item = UnitOfWork.CallRepository.FindById(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }
    }
}
