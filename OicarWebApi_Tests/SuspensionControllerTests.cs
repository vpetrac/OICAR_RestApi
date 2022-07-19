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
    public class SuspensionControllerTests
    {
        private readonly SuspensionController _controller = new SuspensionController();

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
            var suspensions = Assert.IsType<List<Suspension>>(viewResult.Model);
            Assert.NotEmpty(suspensions);
        }
    }
}
