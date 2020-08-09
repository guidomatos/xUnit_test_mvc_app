using LibraryApp.Controllers;
using LibraryMvcApp.Data.MockData;
using LibraryMvcApp.Data.Models;
using LibraryMvcApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace LibraryMvcApp.Test
{
    public class BooksControllerTest
    {
        [Fact]
        public void IndexUnitTest() {
            //arrange
            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(n => n.GetAll()).Returns(MockData.GetTestBookItems());
            var controller = new BooksController(mockRepo.Object);

            //act
            var result = controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewResultBooks = Assert.IsAssignableFrom<List<Book>>(viewResult.ViewData.Model);
            Assert.Equal(5, viewResultBooks.Count);
        }
    }
}
