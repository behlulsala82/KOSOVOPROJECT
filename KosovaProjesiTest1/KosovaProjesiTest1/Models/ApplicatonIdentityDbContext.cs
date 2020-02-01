using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KosovaProjesiTest1.Models
{
    public class ApplicatonIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicatonIdentityDbContext(DbContextOptions<ApplicatonIdentityDbContext> options)
            : base(options)
        {

        }
    }
}
