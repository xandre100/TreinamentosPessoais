using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using treinamento.site.Controllers;
using System.Linq;
using treinamento.site.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;

namespace treinamento.site.Tests.Controllers
{
    /// <summary>
    /// Summary description for UsuariosMockTest
    /// </summary>
    [TestClass]
    public class UsuariosMockTest
    {
        Mock<IUsuariosController> mockController;
        Mock<IRepository> mockRepository;

        private IQueryable<Usuario> usuarios = new List<Usuario>(){
                new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 44444444 },
                new Usuario() { Id = 2, Nome = "SANTOS", Telefone = 55555555 }
                }.AsQueryable();

        private Usuario usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 44444444 };

        public UsuariosMockTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        [TestInitialize()]
        public void MyTestInitialize() {
            mockController = new Mock<IUsuariosController>();
            mockRepository = new Mock<IRepository>();
        }
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
            mockRepository.Setup(r => r.GetUsuarios()).Returns(usuarios);
            mockController.Setup(s => s.GetUsuarios()).Returns(usuarios);

            var _controller = new UsuariosController(mockController.Object, mockRepository.Object);
            var result = _controller.GetUsuarios();
            Assert.IsNotNull(result);
        }

        // GET: api/Usuarios/5
        [TestMethod]
        public void GetUsuarioById()
        {
            mockRepository.Setup(r => r.GetUsuario(It.IsAny<int>())).Returns(usuario);
            mockController.Setup(c => c.GetUsuario(It.IsAny<int>()));

            var _controller = new UsuariosController(mockController.Object, mockRepository.Object);
            var result = _controller.GetUsuario(1) as System.Web.Http.Results.OkNegotiatedContentResult<Usuario>;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Content, typeof(Usuario));
            Assert.AreEqual(result.Content.Id, 1);
        }

        // GET: api/Usuarios/5
        [TestMethod]
        public void GetUsuarioByIdNotFound()
        {
            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.NotFound);
            response = new ResponseMessageResult(responseMsg);

            mockRepository.Setup(r => r.GetUsuario(2)).Returns(usuario);
            mockController.Setup(c => c.GetUsuario(2)).Returns(response);

            var _controller = new UsuariosController(mockController.Object, mockRepository.Object);
            var result = _controller.GetUsuario(1) as System.Web.Http.Results.NotFoundResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.NotFoundResult));
        }

        // PUT: api/Usuarios/5
        [TestMethod]
        public void PutUsuario()
        {
            var usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 44444444 };

            mockRepository.Setup(r => r.PutUsuario(It.IsAny<int>(), It.IsAny<Usuario>()));
            mockController.Setup(c => c.PutUsuario(It.IsAny<int>(), It.IsAny<Usuario>()));

            var _controller = new UsuariosController(mockController.Object, mockRepository.Object);
            var result = _controller.PutUsuario(1, usuario) as System.Web.Http.Results.StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.StatusCodeResult));
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.NoContent);
        }

        // POST: api/Usuarios
        [TestMethod]
        public void PostUsuario()
        {
            var usuario = new Usuario() { Id = 10, Nome = "DNA SEPA", Telefone = 33333333 };

            mockRepository.Setup(r => r.PostUsuario(It.IsAny<Usuario>()));
            mockController.Setup(c => c.PostUsuario(It.IsAny<Usuario>()));

            var _controller = new UsuariosController(mockController.Object, mockRepository.Object);
            var result = _controller.PostUsuario(usuario) as System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<treinamento.site.Usuario>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<treinamento.site.Usuario>));
            Assert.AreEqual(result.Content.Id, 10);
        }

        // DELETE: api/Usuarios/5
        [TestMethod]
        public void DeleteUsuario()
        {
            mockRepository.Setup(r => r.GetUsuario(It.IsAny<int>())).Returns(usuario);
            mockRepository.Setup(r => r.DeleteUsuario(It.IsAny<int>())).Returns(usuario);
            mockController.Setup(c => c.DeleteUsuario(It.IsAny<int>()));

            var _controller = new UsuariosController(mockController.Object, mockRepository.Object);
            var result = _controller.DeleteUsuario(1) as System.Web.Http.Results.OkNegotiatedContentResult<Usuario>;

            Assert.IsInstanceOfType(result.Content, typeof(Usuario));
            Assert.AreEqual(1, result.Content.Id);
        }
    }
}
