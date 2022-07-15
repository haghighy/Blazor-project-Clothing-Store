using Microsoft.EntityFrameworkCore;
using FinalProject.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Shared;

namespace FinalProject.Server.DB
{
    public class ClotheDbContext : DbContext
    {
        public ClotheDbContext(DbContextOptions<ClotheDbContext> options)
            :base(options)
        {}
        public DbSet<Clothe> Clothes{get; set;}
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}