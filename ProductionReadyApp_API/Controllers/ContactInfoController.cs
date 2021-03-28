using Microsoft.AspNetCore.Mvc;
using ProductionReadyApp_API.Models;
using ProductionReadyApp_API.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionReadyApp_API.Environment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductionReadyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoRepo<ContactInfo> _contactInfoRepo;
        public ContactInfoController(IContactInfoRepo<ContactInfo> contactInfoRepo)
        {
            _contactInfoRepo = contactInfoRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ContactInfo> contactInfo = _contactInfoRepo.GetAll();
            
            if (!contactInfo.Any())
            {
                return NotFound(new { Status = ResponseMessage.Code_NotFound, msg = ResponseMessage.Message_RecordNotFound });
            }
            return Ok(new { Status = ResponseMessage.Code_Ok, msg = ResponseMessage.Message_RecordFound, contactInfo });
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            ContactInfo contactInfo = _contactInfoRepo.Get(id);
            if (contactInfo==null)
            {
                return NotFound(new { Status = ResponseMessage.Code_NotFound, msg = ResponseMessage.Message_RecordNotFound });
            }
            return Ok(new { Status = ResponseMessage.Code_Ok, msg = ResponseMessage.Message_RecordFound, contactInfo });
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContactInfo contactInfo)
        {
            string[] validStatus = new string[] { "ACTIVE", "INACTIVE" };
            
            if (contactInfo == null)
            {
                return BadRequest(new { Status = ResponseMessage.Code_BadRequest, msg = ResponseMessage.Message_NullBody });
            }
            if(contactInfo.Status==string.Empty || contactInfo.Status=="")
            {
                contactInfo.Status = "active";
            }
            else if (!validStatus.Contains(contactInfo.Status.ToUpper()))
            {
                return BadRequest(new { Status = ResponseMessage.Code_BadRequest, msg = ResponseMessage.Message_IncorrectContactStatus });
            }
            
            _contactInfoRepo.Add(contactInfo);
            return CreatedAtRoute(
                  "Get",
                  new { Id = contactInfo.ID },
                   new { Status = ResponseMessage.Code_Created, msg = ResponseMessage.Message_RecordCreated, contactInfo });
        }
        // PUT: api/ContactInfo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ContactInfo contactInfo)
        {
            string[] validStatus = new string[] { "ACTIVE", "INACTIVE" };

            if (contactInfo == null)
            {
                return BadRequest(new { Status = ResponseMessage.Code_BadRequest, msg = ResponseMessage.Message_NullBody });
            }
            if(contactInfo.Status!=null || contactInfo.Status.Trim()!="")
            {
                if(!validStatus.Contains(contactInfo.Status.ToUpper()))
                    return BadRequest(new { Status = ResponseMessage.Code_BadRequest, msg = ResponseMessage.Message_IncorrectContactStatus });
            }
            ContactInfo contactInfoToUpdate = _contactInfoRepo.Get(id);
            if (contactInfoToUpdate == null)
            {
                return NotFound(new { Status = ResponseMessage.Code_NotFound, msg = ResponseMessage.Message_RecordNotFound });
            }
            _contactInfoRepo.Update(contactInfoToUpdate, contactInfo);
            return Ok(new { Status = ResponseMessage.Code_Ok, msg = ResponseMessage.Message_RecordUpdated });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ContactInfo contactInfo = _contactInfoRepo.Get(id);
            if (contactInfo == null)
            {
                return NotFound(new { Status = ResponseMessage.Code_NotFound, msg = ResponseMessage.Message_RecordNotFound });
            }
            _contactInfoRepo.Delete(contactInfo);
            return Ok(new { Status = ResponseMessage.Code_Ok, msg = ResponseMessage.Message_RecordDeleted });
        }

    }
}
