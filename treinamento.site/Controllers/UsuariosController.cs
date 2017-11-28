using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using treinamento.site;
using treinamento.site.Models;

namespace treinamento.site.Controllers
{
    public class UsuariosController : ApiController
    {
        private treinamentoEntities db = new treinamentoEntities();
        private IUsuariosController controller;
        private IRepository repository;

        public UsuariosController()
        {
            if (repository == null)
                this.repository = new Repository();
        }

        public UsuariosController(IUsuariosController _controller, IRepository _repository)
        {
            this.controller = _controller;
            this.repository = _repository;
        }

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            return this.repository.GetUsuarios();
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = this.repository.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                this.repository.PutUsuario(id, usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.repository.PostUsuario(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = this.repository.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            this.repository.DeleteUsuario(id);

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}