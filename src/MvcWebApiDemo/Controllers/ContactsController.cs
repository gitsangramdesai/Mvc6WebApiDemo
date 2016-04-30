using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using WebApplication1.AppConfig;
using WebApplication1.Identity;
using WebApplication1.Helper;
using System.IO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        public ContactsController(ILogger<ContactsController> logger, IOptions<AppSettings> appSettings, IApplicationIdentityRepository identityRepository) :base(logger, appSettings, identityRepository)
        {

        }

        
        [HttpGet]//api/Contacts
        public async Task<IEnumerable<Contact>> GetAll()
        {
           // UserProfilePicture dp = await IdentityRepository.GetUserProfilePictureByIdAsync("6");

            string path = "E:\\img\\1.jpg";
            
            byte[] imageInByte = System.IO.File.ReadAllBytes(path);

            bool x =await IdentityRepository.SaveProfilePic(6, "sangram", imageInByte);

            string siteName = AppSettings.SiteSettings.SiteTitle;
            string Logs = AppSettings.LogSettings.AppLogPath;
            return UnitOfWork.ContactRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetContacts")]
        public IActionResult GetById(Guid id)
        {
            var item = UnitOfWork.ContactRepository.FindById(id);
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
            UnitOfWork.ContactRepository.Add(item);
            Logger.LogInformation("You are here!");//just for testing purpose
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Contact item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            var contactObj = UnitOfWork.ContactRepository.FindById(id);
            if (contactObj == null)
            {
                return HttpNotFound();
            }
            UnitOfWork.ContactRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(Contact item)
        {
            UnitOfWork.ContactRepository.Remove(item);
        }
    }
}
