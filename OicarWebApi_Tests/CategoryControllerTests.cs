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
    public class CategoryControllerTests
    {
        private readonly CategoryController _controller = new CategoryController();

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
            var categories = Assert.IsType<List<Category>>(viewResult.Model);
            Assert.NotEmpty(categories);
        }
    }
}
