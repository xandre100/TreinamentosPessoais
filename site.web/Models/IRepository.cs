using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace site.web.Models
{
    public interface IRepository
    {
        Usuario DeleteUsuario(int id);
        Usuario GetUsuario(int? id);
        IQueryable<Usuario> GetUsuarios();
        void PostUsuario(Usuario usuario);
        void PutUsuario(Usuario usuario);
    }
}
