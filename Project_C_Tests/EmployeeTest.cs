using System;
using Xunit;
using System.Linq;
using Project_C;
using Project_C.Data;
using Project_C.Pages;
using Project_C.Services;
using System.Collections.Generic;
using Project_C.Models;


namespace Project_C_Tests
{
    public class EmployeeTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            List<User> expected = new List<User>();

            // Act
            var result = UserService.DisplayEmail("ferdi@cimsolutions.nl");

            // Assert
            Assert.Equal(expected, result);

        }
    }
}
