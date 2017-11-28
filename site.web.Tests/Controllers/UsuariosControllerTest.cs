using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using site.web.Controllers.Usuarios;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using site.web.Models;

namespace site.web.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        private UsuariosController controller;
        private Mock<IRepository> mockRepository;
        private IQueryable<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario() {Id = 1, Nome = "teste 1", Telefone= 11111111},
            new Usuario() {Id = 2, Nome= "teste 2", Telefone = 2222222}
        }.AsQueryable();

        [TestInitialize]
        public void Setup()
        {
            if (mockRepository == null)
                mockRepository = new Mock<IRepository>();
        }

        [TestMethod]
        public void Index()
        {
            mockRepository.Setup(r => r.GetUsuarios()).Returns(usuarios);
            controller = new UsuariosController(mockRepository.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePost()
        {
            Usuario usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 00000000 };
            mockRepository.Setup(r => r.PostUsuario(usuario));
            controller = new UsuariosController(mockRepository.Object);
            RedirectToRouteResult result = controller.Create(usuario) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            ViewResult result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditPost()
        {
            Usuario usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 11111111 };

            mockRepository.Setup(r => r.GetUsuario(It.IsAny<int>())).Returns(usuario);

            controller = new UsuariosController(mockRepository.Object);
            RedirectToRouteResult result = controller.Edit(usuario) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            Usuario usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 222222222 };

            mockRepository.Setup(r => r.GetUsuario(It.IsAny<int>())).Returns(usuario);

            controller = new UsuariosController(mockRepository.Object);

            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteConfirmed()
        {
            Usuario usuario = new Usuario() { Id = 1, Nome = "ALEXANDRE", Telefone = 333333333 };
            
            mockRepository.Setup(r => r.DeleteUsuario(It.IsAny<int>())).Returns(usuario);

            controller = new UsuariosController(mockRepository.Object);

            RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);

        }
    }
}
