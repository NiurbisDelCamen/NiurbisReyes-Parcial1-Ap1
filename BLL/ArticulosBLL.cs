using Microsoft.EntityFrameworkCore;
using Parcial1_Niurbis.DAL;
using Parcial1_Niurbis.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1_Niurbis.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Articulos.Add(articulos) != null)
                    paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(articulos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Articulos Buscar(int id)
        {
            Contexto db = new Contexto();
            Articulos articulo = new Articulos();
            try
            {
                articulo = db.Articulos.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return articulo;
        }
    }
}
