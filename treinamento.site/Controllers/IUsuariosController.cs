using System.Linq;
using System.Web.Http;

namespace treinamento.site.Controllers
{
    public interface IUsuariosController
    {
        IHttpActionResult DeleteUsuario(int id);
        IHttpActionResult GetUsuario(int id);
        IQueryable<Usuario> GetUsuarios();
        IHttpActionResult PostUsuario(Usuario usuario);
        IHttpActionResult PutUsuario(int id, Usuario usuario);
    }
}