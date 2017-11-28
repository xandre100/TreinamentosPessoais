using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace site.web.Models
{
    public class Repository : IRepository
    {
        private treinamentoEntities db = new treinamentoEntities();

        public Repository()
        {

        }

        public Usuario DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return usuario;
        }

        public Usuario GetUsuario(int? id)
        {
            Usuario usuario = db.Usuario.Find(id);

            if (usuario == null)
                return null;

            return usuario;
        }

        public IQueryable<Usuario> GetUsuarios()
        {
            return this.db.Usuario;
        }

        public void PostUsuario(Usuario usuario)
        {
            this.db.Usuario.Add(usuario);
            db.SaveChanges();
        }

        public void PutUsuario(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UsuarioExists(usuario.Id))
                {
                    throw ex;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.Id == id) > 0;
        }
    }
}