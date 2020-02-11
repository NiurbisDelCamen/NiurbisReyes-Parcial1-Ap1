using Microsoft.EntityFrameworkCore;
using Parcial1_Niurbis.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1_Niurbis.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Articulos> Articulo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-HMJOQ71 = Database = Articulos; Trusted_Connection = True;");
        }
    }

}
