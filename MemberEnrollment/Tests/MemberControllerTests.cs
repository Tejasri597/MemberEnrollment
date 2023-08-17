using MemberEnrollment.Repositories;
using MemberEnrollment.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MemberEnrollment.Controllers;
using System;

namespace MemberEnrollment.Tests
{
    public class MemberControllerTests
    {
        [Fact]
        public void CreateMember_ValidMemberProvided_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<MemberRepository>();
            var controller = new MemberController(mockRepository.Object);
            var member = new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Birthdate = new DateTime(1990, 1, 1)
            };

            // Act
            var result = controller.CreateMember(member);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void CreateMember_InvalidMember_ReturnsBadRequest()
        {
            // Arrange
            var mockRepository = new Mock<MemberRepository>();
            var controller = new MemberController(mockRepository.Object);
            var member = new Member(); // Invalid member with missing required properties

            // Act
            var result = controller.CreateMember(member);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);

            // Additional check for validation error messages
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
            Assert.True(controller.ModelState.ErrorCount > 0);
        }

        [Fact]
        public void CreateMember_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            var mockRepository = new Mock<MemberRepository>();
            var controller = new MemberController(mockRepository.Object);
            var member = new Member
            {
                // Missing required properties
            };

            // Act
            controller.ModelState.AddModelError("FirstName", "The FirstName field is required.");
            controller.ModelState.AddModelError("LastName", "The LastName field is required.");
            var result = controller.CreateMember(member);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);

            // Additional check for validation error messages
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
            Assert.True(controller.ModelState.ErrorCount > 0);
        }

        // Additional tests for other controller actions and repository methods can be added here.
    }
}
