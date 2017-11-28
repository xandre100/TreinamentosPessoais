using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treinamento.site.Models
{
    public interface IRepository
    {
        Usuario DeleteUsuario(int id);
        Usuario GetUsuario(int id);
        IQueryable<Usuario> GetUsuarios();
        void PostUsuario(Usuario usuario);
        void PutUsuario(int id, Usuario usuario);
    }
}