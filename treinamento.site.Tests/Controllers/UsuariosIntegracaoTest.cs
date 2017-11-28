using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using treinamento.site.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace treinamento.site.Tests.Controllers
{
    /// <summary>
    /// Summary description for UsuariosIntegracaoTest
    /// </summary>
    [TestClass]
    public class UsuariosIntegracaoTest
    {
        UsuariosController _controller;
        
        public UsuariosIntegracaoTest()
        {
            //
            // TODO: Add constructor logic here
            //

            _controller = new UsuariosController();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        // GET: api/Usuarios
        public void GetUsuarios()
        {
            IQueryable<Usuario> result = _controller.GetUsuarios();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        // GET: api/Usuarios/5
        [TestMethod]
        public void GetUsuarioById()
        {
            var result = _controller.GetUsuario(1) as System.Web.Http.Results.OkNegotiatedContentResult<Usuario>;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Content, typeof(Usuario));
            Assert.AreEqual(result.Content.Nome, "ALEXANDRE");
        }

        // PUT: api/Usuarios/5
        [TestMethod]
        public void PutUsuario()
        {
            var usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 44444444 };
            
            var result = _controller.PutUsuario(1, usuario) as System.Web.Http.Results.StatusCodeResult;

            var usuarioAlterado = _controller.GetUsuario(1) as System.Web.Http.Results.OkNegotiatedContentResult<Usuario>;
            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.StatusCodeResult));
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.NoContent);
            Assert.AreEqual(usuarioAlterado.Content.Telefone, 44444444);
        }

        // POST: api/Usuarios
        [TestMethod]
        public void PostUsuario()
        {
            var usuario = new Usuario() { Nome = "DNA SEPA", Telefone = 33333333 };
            var result = _controller.PostUsuario(usuario) as System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<treinamento.site.Usuario>;
            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<treinamento.site.Usuario>));
        }

        // DELETE: api/Usuarios/5
        [TestMethod]
        public void DeleteUsuario()
        {
            IQueryable<Usuario> usuarios = _controller.GetUsuarios();
            var result = _controller.DeleteUsuario(7) as System.Web.Http.Results.OkNegotiatedContentResult<Usuario>;
            Assert.IsNotNull(usuarios);
            //Assert.IsInstanceOfType(result.Content, typeof(Usuario));
            //Assert.AreEqual(7, result.Content.Id);

        }

    }
}
