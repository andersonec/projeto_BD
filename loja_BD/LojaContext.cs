using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using loja_BD.Models;

namespace loja_BD
{
    public class LojaContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public LojaContext(DbContextOptions<LojaContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasKey(c => c.id);
        }
    }
}   
