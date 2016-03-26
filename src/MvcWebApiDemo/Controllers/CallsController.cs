using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;
using Microsoft.AspNet.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class CallsController : Controller
    {
        [FromServices]
        public ICallRepository CallsRepo { get; set; }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Call item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            CallsRepo.Add(item);
            return CreatedAtRoute("GetCalls", new { Controller = "Calls", id = item.ID }, item);
        }

        [HttpGet("{id}", Name = "GetCalls")]
        public IActionResult GetById(Guid id)
        {
            System.Diagnostics.Debugger.Break();
            var item = CallsRepo.FindById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }
    }
}
