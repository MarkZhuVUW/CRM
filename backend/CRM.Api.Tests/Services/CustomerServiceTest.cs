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
        public async Task GetCustomers_ValidPagination_ReturnsCorrectPage()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 2, It.IsAny<CustomerFilter>(), "name", "asc")).ReturnsAsync(customers.Take(2).ToList());

            // When
            var response = await _customerService.GetCustomers(1, 2, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Data.Count());
            Assert.AreEqual(3, response.Meta.TotalCount);
        }
        
        [TestMethod]
        public async Task GetCustomers_AscendingSortDirection_ReturnsSortedCustomers()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, It.IsAny<CustomerFilter>(), "name", "asc"))
                .ReturnsAsync(customers.OrderBy(c => c.Name).ToList());

            // When
            var response = await _customerService.GetCustomers(1, 10, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name); // Alice should be first in ascending order
        }

        [TestMethod]
        public async Task GetCustomers_DescendingSortDirection_ReturnsSortedCustomers()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, It.IsAny<CustomerFilter>(), "name", "desc"))
                .ReturnsAsync(customers.OrderByDescending(c => c.Name).ToList());

            // When
            var response = await _customerService.GetCustomers(1, 10, filter, "name", "desc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Data.Count());
            Assert.AreEqual("Charlie", response.Data.First().Name); // Charlie should be first in descending order
        }

        [TestMethod]
        public async Task GetCustomers_InvalidSortDirection_ThrowsBadRequestException()
        {
            // Given
            var filter = "status=Active";

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.GetCustomers(1, 10, filter, "name", "invalidDirection"));

            // Then
            Assert.AreEqual("Invalid parameters: Invalid sort direction. Allowed values: asc, desc", exception.Message);
        }

        [TestMethod]
        public async Task GetCustomers_SecondPage_ReturnsRemainingCustomers()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(2, 2, It.IsAny<CustomerFilter>(), "name", "asc")).ReturnsAsync(customers.Skip(2).Take(2).ToList());

            // When
            var response = await _customerService.GetCustomers(2, 2, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Data.Count());
            Assert.AreEqual("Charlie", response.Data.First().Name);
        }

        [TestMethod]
        public async Task GetCustomers_ValidFilter_ReturnsFilteredCustomers()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Non-Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(1);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, It.IsAny<CustomerFilter>(), "name", "asc")).ReturnsAsync(new List<Customer> { customers[0] });

            // When
            var response = await _customerService.GetCustomers(1, 10, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name);
        }

        [TestMethod]
        public async Task GetCustomers_ValidSort_ReturnsSortedCustomers()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, It.IsAny<CustomerFilter>(), "name", "asc")).ReturnsAsync(customers.OrderBy(c => c.Name).ToList());

            // When
            var response = await _customerService.GetCustomers(1, 10, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name); // Should be the first after sorting
        }

        [TestMethod]
        public async Task GetCustomers_MultipleFiltersAndSort_ReturnsCorrectResults()
        {
            // Given
            var filter = "status=Active";
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), Name = "Charlie", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Alice", Status = "Active" },
                new Customer { Id = Guid.NewGuid(), Name = "Bob", Status = "Active" }
            };

            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, It.IsAny<CustomerFilter>(), "name", "asc")).ReturnsAsync(customers.OrderBy(c => c.Name).ToList());

            // When
            var response = await _customerService.GetCustomers(1, 10, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Data.Count());
            Assert.AreEqual("Alice", response.Data.First().Name); // Should be the first after sorting
        }

        [TestMethod]
        public async Task GetCustomers_ValidParameters_ReturnsCustomerGetResponse()
        {
            // Given
            var filter = "status=Active";
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
            _customerDaoMock.Setup(x => x.GetTotalCount(It.IsAny<CustomerFilter>())).ReturnsAsync(customers.Count);
            _customerDaoMock.Setup(x => x.GetCustomers(1, 10, It.IsAny<CustomerFilter>(), "name", "asc")).ReturnsAsync(customers);

            // When
            var response = await _customerService.GetCustomers(1, 10, filter, "name", "asc");

            // Then
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Data.Count());
            Assert.AreEqual(1, response.Meta.TotalCount);
        }

        [TestMethod]
        public async Task GetCustomers_InvalidPageNumber_ThrowsBadRequestException()
        {
            // Given
            var filter = "status=Active";

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.GetCustomers(0, 10, filter, "name", "asc"));

            // Then
            Assert.AreEqual("Invalid parameters: Page number must be greater than 0.", exception.Message);
        }

        [TestMethod]
        public async Task GetCustomers_InvalidPageSize_ThrowsBadRequestException()
        {
            // Given
            var filter = "status=Active";

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.GetCustomers(1, 0, filter, "name", "asc"));

            // Then
            Assert.AreEqual("Invalid parameters: Page size must be greater than 0.", exception.Message);
        }

        [TestMethod]
        public async Task GetCustomers_InvalidStatus_ThrowsBadRequestException()
        {
            // Given
            var filter = "status=Invalid Status"; // Invalid status

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.GetCustomers(1, 10, filter, "name", "asc"));

            // Then
            Assert.AreEqual("Invalid parameters: Invalid status value.", exception.Message);
        }

        [TestMethod]
        public async Task GetCustomers_InvalidSortValue_ThrowsBadRequestException()
        {
            // Given
            var filter = "name=bla,status=Active";

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.GetCustomers(1, 10, filter, "invalidSort", "asc"));

            // Then
            Assert.AreEqual("Invalid parameters: Invalid sort value. Allowed values: name, status, ", exception.Message);
        }

        [TestMethod]
        public async Task GetCustomers_InvalidFilter_ThrowsBadRequestException()
        {
            // Given
            var filter = "name=bla,asd=active";

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.GetCustomers(1, 10, filter, "invalidSort", "asc"));

            // Then
            Assert.AreEqual("Invalid filter = " + filter, exception.Message);
        }

        [TestMethod]
        public async Task GetCustomerById_ValidId_ReturnsCustomerDto()
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
            _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).ReturnsAsync(customer);

            // When
            var result = await _customerService.GetCustomerById(customerId);

            // Then
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.Id);
            Assert.AreEqual("Jane Doe", result.Name);
        }

        [TestMethod]
        public async Task GetCustomerById_InvalidId_ThrowsNotFoundException()
        {
            // Given
            var customerId = Guid.NewGuid();
            _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).ReturnsAsync((Customer)null);

            // When
            var exception = await Assert.ThrowsExceptionAsync<NotFoundException>(() =>
                _customerService.GetCustomerById(customerId));

            // Then
            Assert.AreEqual($"Customer not found for customer id = {customerId}", exception.Message);
        }
        
        [TestMethod]
        public async Task UpdateCustomer_CustomerNotFound_ThrowsNotFoundException()
        {
            // Given
            var customerId = Guid.NewGuid();
            var updateRequest = new CustomerDto
            {
                Status = "Active",
            };

            _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).ReturnsAsync((Customer)null);

            // When
            var exception = await Assert.ThrowsExceptionAsync<NotFoundException>(() =>
                _customerService.UpdateCustomer(customerId.ToString(), updateRequest));

            // Then
            Assert.AreEqual($"Customer not found for customerId: " + customerId, exception.Message);
        }

        [TestMethod]
        public async Task UpdateCustomer_InvalidStatus_ThrowsBadRequestException()
        {
            // Given
            var customerId = Guid.NewGuid();
            var dto = new CustomerDto
            {
                Status = "InvalidStatus"
                
            };

            // When
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(() =>
                _customerService.UpdateCustomer(customerId.ToString(), dto));

            // Then
            Assert.AreEqual("Invalid status provided. pathCustomerId = " + customerId, exception.Message);
        }
    }
}