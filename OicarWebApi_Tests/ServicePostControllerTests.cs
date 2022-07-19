using Microsoft.AspNetCore.Mvc;
using OicarWebApi.Controllers;
using OicarWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OicarWebApi_Tests
{
    public class ServicePostControllerTests
    {
        private readonly ServicePostController _controller = new ServicePostController();

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get(1006);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {

            var result = _controller.Get();
            var viewResult = Assert.IsType<ViewResult>(result);
            var servicePosts = Assert.IsType<List<ServicePost>>(viewResult.Model);
            Assert.NotEmpty(servicePosts);
        }
    }
}
