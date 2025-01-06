using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using csahrpstock.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions DbContextOptions)
        : base(DbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock {get; set;}
        public DbSet<Comment> Comment {get; set;}
        
    }
}