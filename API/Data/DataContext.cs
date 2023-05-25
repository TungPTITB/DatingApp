using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Thing
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){

        }
        public DbSet<AppUser> Users { get; set; }
    }
}