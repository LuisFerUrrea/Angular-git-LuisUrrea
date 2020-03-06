using Microsoft.EntityFrameworkCore;
using ProyectoAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAngular.Context
{
    public class ContextDB : DbContext, IContextDB
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().ToTable("Messsages");

        }
    }
}
