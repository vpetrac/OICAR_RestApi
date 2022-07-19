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
    public class ReviewControllerTests
    {
        private readonly ReviewController _controller = new ReviewController();

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get(1006);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {

            var result = _controller.GetForUser(1008);
            var viewResult = Assert.IsType<ViewResult>(result);
            var reviews = Assert.IsType<List<Review>>(viewResult.Model);
            Assert.NotEmpty(reviews);
        }
    }
}
