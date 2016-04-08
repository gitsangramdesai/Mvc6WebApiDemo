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
    public class ContactsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return unitOfWork.ContactRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetContacts")]
        public IActionResult GetById(Guid id)
        {
            var item = unitOfWork.ContactRepository.FindById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            unitOfWork.ContactRepository.Add(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Contact item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            var contactObj = unitOfWork.ContactRepository.FindById(id);
            if (contactObj == null)
            {
                return HttpNotFound();
            }
            unitOfWork.ContactRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(Contact item)
        {
            unitOfWork.ContactRepository.Remove(item);
        }
    }
}
