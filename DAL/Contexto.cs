using Microsoft.EntityFrameworkCore;
using Parcial1_Niurbis.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1_Niurbis.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Inventario.db");
        }
    }

}
