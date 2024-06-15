using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Students_POO2.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Students_POO2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctores> Doctores {get; set;}

    }
}