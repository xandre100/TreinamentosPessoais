using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace treinamento.site.Models
{
    public class Repository : IRepository
    {
        private treinamentoEntities db = new treinamentoEntities();

        public Repository()
        {

        }


        public Usuario DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        public void PostUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void PutUsuario(int id, Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UsuarioExists(id))
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
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}