using EmployeeServer.Controllers;
using EmployeeServer.Models;
using EmployeeServer.Repositories;
using EmployeeServer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeServerTest
{
    public class EmployeeControllerTest
    {
        [Fact]
        public void Index_ReturnsOkResult()
        {
            //Arrange
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            mockEmployeeRepo.Setup(repo => repo.GetEmployeesOrderedByCreatedAtDesc()).Returns([]);
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            
        }
        [Fact]
        public async Task GetOne_ReturnsOkResult()
        {
            //Arrange
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var id = Guid.NewGuid();
            var employee = new Employee
            {
                Id = id,
            };
            mockEmployeeRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(employee);
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.GetOne(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async Task GetOne_ReturnsNotFoundResultIfIdIsEmpty()
        {
            //Arrange
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var id = Guid.NewGuid();
            var employee = new Employee 
            {
                Id = id,
            };
            mockEmployeeRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(employee);
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.GetOne(Guid.Empty);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }
        [Fact]
        public async Task GetOne_ReturnsNotFoundResultIfEmployeeRecordDoesntExists()
        {
            //Arrange
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var id = Guid.NewGuid();
            Employee? employee = null;
            mockEmployeeRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(employee);
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.GetOne(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }
        [Fact]
        public async Task Create_ReturnsOkResult()
        {
            //Arrange
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            EmployeeViewModel vm = new EmployeeViewModel {
                GivenName = "John",
                MiddleName = "A.",
                Surname = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "123 Main St",
                SSNumber = "123-45-6789",
                TIN = "987-65-4321",
                MIDNumber = "M1234567",
                PhilHealthNumber = "PH1234567",
                MobileNumber = "09123456789",
                Email = "john.doe@example.com"

            };
            var employee = new Employee(vm);
            mockEmployeeRepo.Setup(repo => repo.CreateAsync(employee)).ReturnsAsync(employee);
   
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);


            //Act
            var result = await controller.Create(vm);

            //Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async Task Create_ReturnsBadRequestResultIfModelStateIsInvalid()
        {
            //Arrange
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            EmployeeViewModel vm = new EmployeeViewModel
            {
                GivenName = "", //empty
                MiddleName = "A.",
                Surname = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "123 Main St",
                SSNumber = null, //empty
                TIN = "987-65-4321",
                MIDNumber = "M1234567",
                PhilHealthNumber = "PH1234567",
                MobileNumber = "09123456789",
                Email = "john.doe@example.com"

            };
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);
            controller.ModelState.AddModelError("givenName", "Given name is required");
            controller.ModelState.AddModelError("ssNumber", "SSNumber is required.");

            //Act
            var result = await controller.Create(vm);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);

        }
        [Fact]
        public async Task Update_ReturnOkResult()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var id = Guid.NewGuid();
            EmployeeViewModel vm = new EmployeeViewModel
            {
                GivenName = "John",
                MiddleName = "A.",
                Surname = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "123 Main St",
                SSNumber = "123-45-6789",
                TIN = "987-65-4321",
                MIDNumber = "M1234567",
                PhilHealthNumber = "PH1234567",
                MobileNumber = "09123456789",
                Email = "john.doe@example.com"

            };
            Employee? employee = new Employee { Id = id };
           
            mockEmployeeRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(employee);
;           var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.Update(vm, id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Update_ReturnBadResultIfGuidIsEmpty()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            EmployeeViewModel vm = new EmployeeViewModel
            {
                GivenName = "John",
                MiddleName = "A.",
                Surname = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "123 Main St",
                SSNumber = "123-45-6789",
                TIN = "987-65-4321",
                MIDNumber = "M1234567",
                PhilHealthNumber = "PH1234567",
                MobileNumber = "09123456789",
                Email = "john.doe@example.com"

            };
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.Update(vm, Guid.Empty);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task Update_ReturnNotFoundIfEmployeeRecordDoesntExists()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var id = Guid.NewGuid();
            EmployeeViewModel vm = new EmployeeViewModel
            {
                GivenName = "John",
                MiddleName = "A.",
                Surname = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "123 Main St",
                SSNumber = "123-45-6789",
                TIN = "987-65-4321",
                MIDNumber = "M1234567",
                PhilHealthNumber = "PH1234567",
                MobileNumber = "09123456789",
                Email = "john.doe@example.com"

            };
            Employee? employee = null;
            mockEmployeeRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(employee);
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.Update(vm, Guid.Empty);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnOkResult()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var id = Guid.NewGuid();
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Delete_ReturnNotFoundIfGuidIsEmpty()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var controller = new EmployeeController(mockLogger.Object, mockEmployeeRepo.Object);

            //Act
            var result = await controller.Delete(Guid.Empty);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}