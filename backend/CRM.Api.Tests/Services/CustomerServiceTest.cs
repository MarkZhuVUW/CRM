using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Models;
using CRM.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace CRM.Api.Tests.Services
{
    [TestClass]
    public class CustomerServiceTests
    {
        private Mock<ICustomerDao> _customerDaoMock;
        private Mock<ILogger<CustomerService>> _loggerMock;
        private CustomerService _customerService;

        [TestInitialize]
        public void Setup()
        {
            _customerDaoMock = new Mock<ICustomerDao>();
            _loggerMock = new Mock<ILogger<CustomerService>>();
            _customerService = new CustomerService(_customerDaoMock.Object, _loggerMock.Object);
        }

        [TestMethod]
        public void GetCustomers_ValidPagination_ReturnsCorrectPage()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" }
            };
    
            _customerDaoMock.Setup(x => x.GetTotalCount(filter)).Returns(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 2, filter, "name")).Returns(customers.Take(2).ToList());

            // When
            var response = _customerService.GetCustomers(1, 2, filter, "name");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Data.Count());
            Assert.AreEqual(3, response.Meta.TotalCount);
        }

        [TestMethod]
        public void GetCustomers_SecondPage_ReturnsRemainingCustomers()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(filter)).Returns(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(2, 2, filter, "name")).Returns(customers.Skip(2).Take(2).ToList());

            // When
            var response = _customerService.GetCustomers(2, 2, filter, "name");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Data.Count());
            Assert.AreEqual("Charlie", response.Data.First().Name);
        }

        [TestMethod]
        public void GetCustomers_ValidFilter_ReturnsFilteredCustomers()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Non Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(filter)).Returns(1);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, filter, "name")).Returns(new List<Customer> { customers[0] });

            // When
            var response = _customerService.GetCustomers(1, 10, filter, "name");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name);
        }

        [TestMethod]
        public void GetCustomers_ValidSort_ReturnsSortedCustomers()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(filter)).Returns(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, filter, "name")).Returns(customers.OrderBy(c => c.Name).ToList());

            // When
            var response = _customerService.GetCustomers(1, 10, filter, "name");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name); // Should be the first after sorting
        }

        [TestMethod]
        public void GetCustomers_MultipleFiltersAndSort_ReturnsCorrectResults()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(filter)).Returns(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, filter, "name")).Returns(customers.OrderBy(c => c.Name).ToList());

            // When
            var response = _customerService.GetCustomers(1, 10, filter, "name");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name); // Should be the first after sorting
        }

        [TestMethod]
        public void GetCustomers_ValidParameters_ReturnsCustomerGetResponse()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Status = "Active",
                    Email = "john@example.com",
                    PhoneNumber = "123456789",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
            _customerDaoMock.Setup(x => x.GetTotalCount(filter)).Returns(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, filter, "name")).Returns(customers);

            // When
            var response = _customerService.GetCustomers(1, 10, filter, "name");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Data.Count());
            Assert.AreEqual(1, response.Meta.TotalCount);
        }

        [TestMethod]
        public void GetCustomers_InvalidPageNumber_ThrowsBadRequestException()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };

            // When
            var exception = Assert.ThrowsException<BadRequestException>(() => 
                _customerService.GetCustomers(0, 10, filter, "name"));

            // Then
            Assert.AreEqual("Invalid parameters: Page number must be greater than 0.", exception.Message);
        }

        [TestMethod]
        public void GetCustomers_InvalidPageSize_ThrowsBadRequestException()
        {
            // Given
            var filter = new CustomerFilter { Status = "Active" };

            // When
            var exception = Assert.ThrowsException<BadRequestException>(() => 
                _customerService.GetCustomers(1, 0, filter, "name"));

            // Then
            Assert.AreEqual("Invalid parameters: Page size must be greater than 0.", exception.Message);
        }

        [TestMethod]
        public void GetCustomers_InvalidStatus_ThrowsBadRequestException()
        {
            // Given
            var filter = new CustomerFilter { Status = "invalid status" }; // Invalid status

            // When
            var exception = Assert.ThrowsException<BadRequestException>(() => 
                _customerService.GetCustomers(1, 10, filter, "name"));

            // Then
            Assert.AreEqual("Invalid parameters: Invalid status value.", exception.Message);
        }

        [TestMethod]
        public void GetCustomers_InvalidSortValue_ThrowsBadRequestException()
        {
            // Given
            var filter = new CustomerFilter();

            // When
            var exception = Assert.ThrowsException<BadRequestException>(() => 
                _customerService.GetCustomers(1, 10, filter, "invalidSort"));

            // Then
            Assert.AreEqual("Invalid parameters: Invalid sort value. Allowed values: name, status", exception.Message);
        }

        [TestMethod]
        public void GetCustomerById_ValidId_ReturnsCustomerDto()
        {
            // Given
            var customerId = Guid.NewGuid();
            var customer = new Customer
            {
                Id = customerId,
                Name = "Jane Doe",
                Status = "Active",
                Email = "jane@example.com",
                PhoneNumber = "987654321",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns(customer);

            // When
            var result = _customerService.GetCustomerById(customerId);

            // Then
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.Id);
            Assert.AreEqual("Jane Doe", result.Name);
        }

        [TestMethod]
        public void GetCustomerById_InvalidId_ThrowsNotFoundException()
        {
            // Given
            var customerId = Guid.NewGuid();
            _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns((Customer)null);

            // When
            var exception = Assert.ThrowsException<NotFoundException>(() => 
                _customerService.GetCustomerById(customerId));

            // Then
            Assert.AreEqual($"customer not found for customer id = {customerId}", exception.Message);
        }

        [TestMethod]
        public void UpdateCustomer_ValidCustomer_UpdatesSuccessfully()
        {
            // Given
            var customerId = Guid.NewGuid();
            var customerDto = new CustomerDto
            {
                Id = customerId,
                Name = "John Doe",
                Status = "Active",
                Email = "john@example.com",
                PhoneNumber = "123456789",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns(new Customer { Id = customerId });

            // When
            _customerService.UpdateCustomer(customerId.ToString(), customerDto);

            // Then
            _customerDaoMock.Verify(x => x.UpdateCustomer(It.IsAny<Customer>()), Times.Once);
        }

        [TestMethod]
        public void UpdateCustomer_PathIdDoesNotMatchDtoId_ThrowsBadRequestException()
        {
            // Given
            var pathCustomerId = Guid.NewGuid().ToString();
            var customerDto = new CustomerDto
            {
                Id = Guid.NewGuid(), // Different Id
                Name = "John Doe",
                Status = "Active",
                Email = "john@example.com",
                PhoneNumber = "123456789"
            };

            // When
            var exception = Assert.ThrowsException<BadRequestException>(() => 
                _customerService.UpdateCustomer(pathCustomerId, customerDto));

            // Then
            Assert.AreEqual($"path customer id or path opportunity id do not match the value in dto. pathCustomerId = {pathCustomerId} dto = {customerDto}", exception.Message);
        }

        [TestMethod]
        public void UpdateCustomer_InvalidCustomerData_ThrowsBadRequestException()
        {
            // Given
            var pathCustomerId = Guid.NewGuid().ToString();
            var customerDto = new CustomerDto { Id = Guid.NewGuid(), Name = "", Email = "", PhoneNumber = "" }; // Invalid data
            _customerDaoMock.Setup(x => x.GetCustomerById(customerDto.Id)).Returns(new Customer { Id = customerDto.Id });

            // When
            var exception = Assert.ThrowsException<BadRequestException>(() => 
                _customerService.UpdateCustomer(pathCustomerId, customerDto));

            // Then
            Assert.AreEqual("Customer not valid: Customer name cannot be empty, Invalid email address, Phone number cannot be empty", exception.Message);
        }
    }
}