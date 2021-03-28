using ProductionReadyApp_API.Models;
using ProductionReadyApp_API.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionReadyApp_API.Repository.Implementation
{
    public class ContactInfoRepo: IContactInfoRepo<ContactInfo>
    {
         readonly ContactInfoContext _contactInfoContext;
        public ContactInfoRepo(ContactInfoContext context)
        {
            _contactInfoContext = context;
        }
        public IEnumerable<ContactInfo> GetAll()
        {
            return _contactInfoContext.ContactInformations.ToList();
        }
        public ContactInfo Get(int id)
        {
            return _contactInfoContext.ContactInformations
                  .FirstOrDefault(e => e.ID == id);
        }
        public void Add(ContactInfo entity)
        {
            if (entity.Status != null || entity.Status.Trim() != "")
                entity.Status=entity.Status.ToLower();
            _contactInfoContext.ContactInformations.Add(entity);
            _contactInfoContext.SaveChanges();
        }
        public void Update(ContactInfo contactInfo, ContactInfo entity)
        {
            if (entity.FirstName != null ||entity.FirstName.Trim()!="")
                contactInfo.FirstName = entity.FirstName;
            if (entity.LastName != null || entity.LastName.Trim()!="")
                contactInfo.LastName = entity.LastName;
            if (entity.Email != null || entity.Email.Trim()!="")
                contactInfo.Email = entity.Email;
            if (entity.Status != null || entity.Status.Trim()!="")
                contactInfo.Status = entity.Status.ToLower();
            if (entity.PhoneNumber != null || entity.PhoneNumber.Trim()!="")
                contactInfo.PhoneNumber = entity.PhoneNumber;
            _contactInfoContext.SaveChanges();
        }
        public void Delete(ContactInfo contactInfo)
        {
            _contactInfoContext.ContactInformations.Remove(contactInfo);
            _contactInfoContext.SaveChanges();
        }
    }
}
