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
    public class ProjectPostControllerTests
    {
        private readonly ProjectPostController _controller = new ProjectPostController();

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get(1006);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {

            var result = _controller.Get();
            var viewResult = Assert.IsType<ProjectPost>(result);
            var projectPosts = Assert.IsType<List<ProjectPost>>(viewResult.Model);
            Assert.NotEmpty(projectPosts);
        }
    }
}
