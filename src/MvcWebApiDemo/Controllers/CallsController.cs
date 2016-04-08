using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;
using Microsoft.AspNet.Mvc;
using WebApplication1.UnitOfWork;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class CallsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] Call item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            unitOfWork.CallRepository.Add(item);
            return CreatedAtRoute("GetCalls", new { Controller = "Calls", id = item.ID }, item);
        }
        [HttpGet("{id}", Name = "GetCalls")]
        public IActionResult GetById(Guid id)
        {
            System.Diagnostics.Debugger.Break();
            var item = unitOfWork.CallRepository.FindById(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }
    }
}
