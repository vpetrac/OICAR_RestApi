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
    public class ReportControllerTests
    {
        private readonly ReportController _controller = new ReportController();

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get(1006);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {

            var result = _controller.Get();
            var viewResult = Assert.IsType<Report>(result);
            var projectPosts = Assert.IsType<List<Report>>(viewResult.Model);
            Assert.NotEmpty(projectPosts);
        }
    }
}
