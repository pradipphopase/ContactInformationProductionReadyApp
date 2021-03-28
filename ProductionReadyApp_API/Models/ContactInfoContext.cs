using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionReadyApp_API.Models
{
    public class ContactInfoContext:DbContext
    {
        public ContactInfoContext(DbContextOptions options)
              : base(options)
        {
        }
        public DbSet<ContactInfo> ContactInformations { get; set; }
    }
}
