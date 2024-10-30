using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Models;
using CRM.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace CRM.Api.Tests.Services;

[TestClass]
public class CustomerServiceTest
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
    public void GetCustomers_ReturnsCustomerDtos_WhenCustomersExist()
    {
        // Given
        var pageNumber = 1;
        var pageSize = 10;
        var filter = string.Empty;
        var sort = string.Empty;
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "John Doe", Status = "Active", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "Jane Smith", Status = "Non-Active", CreatedAt = DateTime.Now }
        };
        _customerDaoMock.Setup(x => x.GetCustomers(pageNumber, pageSize, filter, sort)).Returns(customers);

        // When
        var result = _customerService.GetCustomers(pageNumber, pageSize, filter, sort).ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(customers[0].Name, result[0].Name);
        Assert.AreEqual(customers[1].Name, result[1].Name);
    }

    [TestMethod]
    public void GetCustomerById_ReturnsCustomerDto_WhenCustomerExists()
    {
        // Given
        var customerId = Guid.NewGuid();
        var customer = new Customer { Id = customerId, Name = "John Doe", Status = "Active", CreatedAt = DateTime.Now };
        _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns(customer);

        // When
        var result = _customerService.GetCustomerById(customerId);

        // Then
        Assert.AreEqual(customerId, result.Id);
        Assert.AreEqual(customer.Name, result.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void GetCustomerById_ThrowsNotFoundException_WhenCustomerDoesNotExist()
    {
        // Given
        var customerId = Guid.NewGuid();
        _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns((Customer)null);

        // When
        _customerService.GetCustomerById(customerId);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    public void UpdateCustomer_UpdatesCustomer_WhenCustomerIsValid()
    {
        // Given
        var customerId = Guid.NewGuid();
        var customerDto = new CustomerDto { Id = customerId, Name = "John Doe", Status = "Active", Email = "john.doe@example.com", PhoneNumber = "1234567890", CreatedAt = DateTime.Now };
        _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns(new Customer { Id = customerId });

        // When
        _customerService.UpdateCustomer(customerId.ToString(), customerDto);

        // Then
        _customerDaoMock.Verify(x => x.UpdateCustomer(It.IsAny<Customer>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateCustomer_ThrowsNotFoundException_WhenCustomerDoesNotExist()
    {
        // Given
        var customerId = Guid.NewGuid();
        var customerDto = new CustomerDto { Id = customerId, Name = "Valid Name", Email = "valid@example.com", PhoneNumber = "1234567890", Status = "Active" };

        // Set up the DAO mock to return "" for the customer lookup
        _customerDaoMock.Setup(x => x.GetCustomerById(customerId)).Returns((Customer)null);

        // When
        _customerService.UpdateCustomer(customerId.ToString(), customerDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public void UpdateCustomer_ThrowsBadRequestException_WhenCustomerDtoIsInvalid()
    {
        // Given
        var customerId = Guid.NewGuid();
        var customerDto = new CustomerDto { Id = customerId, Name = "", Status = "InvalidStatus" };

        // When
        _customerService.UpdateCustomer(customerId.ToString(), customerDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public void UpdateCustomer_ThrowsBadRequestException_WhenPathIdDoesNotMatchDtoId()
    {
        // Given
        var customerDto = new CustomerDto { Id = Guid.NewGuid(), Name = "John Doe", Status = "Active" };
        var pathCustomerId = Guid.NewGuid().ToString();

        // When
        _customerService.UpdateCustomer(pathCustomerId, customerDto);

        // Then - ExpectedException will validate this
    }
        
    // pagination tests
    [TestMethod]
    public void GetCustomers_ReturnsPagedCustomers_WhenValidPageNumberAndSize()
    {
        // Given
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "Customer 1", Status = "Active", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "Customer 2", Status = "Active", CreatedAt = DateTime.Now },
        };

        _customerDaoMock.Setup(x => x.GetCustomers(1, 2, "", "")).Returns(customers);

        // When
        var result = _customerService.GetCustomers(1, 2, "", "").ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.All(c => c.Status == "Active"));
    }

    [TestMethod]
    public void GetCustomers_ReturnsEmpty_WhenNoCustomersAvailable()
    {
        // Given
        _customerDaoMock.Setup(x => x.GetCustomers(1, 2, "", "")).Returns(new List<Customer>());

        // When
        var result = _customerService.GetCustomers(1, 2, "", "").ToList();

        // Then
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void GetCustomers_ReturnsSingleCustomer_WhenLessThanPageSize()
    {
        // Given
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "Customer 1", Status = "Active", CreatedAt = DateTime.Now }
        };

        _customerDaoMock.Setup(x => x.GetCustomers(1, 2, "", "")).Returns(customers);

        // When
        var result = _customerService.GetCustomers(1, 2, "", "").ToList();

        // Then
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Customer 1", result[0].Name);
    }

    [TestMethod]
    public void GetCustomers_ReturnsExactPageSize_WhenExactlyMatching()
    {
        // Given
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "Customer 1", Status = "Active", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "Customer 2", Status = "Active", CreatedAt = DateTime.Now }
        };

        _customerDaoMock.Setup(x => x.GetCustomers(1, 2, "", "")).Returns(customers);

        // When
        var result = _customerService.GetCustomers(1, 2, "", "").ToList();

        // Then
        Assert.AreEqual(2, result.Count);
    }
    
    // filter and sort tests
    [TestMethod]
    public void GetCustomers_ReturnsFilteredCustomers_WhenFilterIsApplied()
    {
        // Given
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "Active Customer", Status = "Active", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "Inactive Customer", Status = "Inactive", CreatedAt = DateTime.Now },
        };

        _customerDaoMock.Setup(x => x.GetCustomers(1, 10, "Active", "")).Returns(customers.Where(c => c.Status == "Active").ToList());

        // When
        var result = _customerService.GetCustomers(1, 10, "Active", "").ToList();

        // Then
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Active Customer", result[0].Name);
    }

    [TestMethod]
    public void GetCustomers_ReturnsSortedCustomers_WhenSortIsApplied()
    {
        // Given
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "B Customer", Status = "Active", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "A Customer", Status = "Active", CreatedAt = DateTime.Now },
        };

        _customerDaoMock.Setup(x => x.GetCustomers(1, 10, "", "Name")).Returns(customers.OrderBy(c => c.Name).ToList());

        // When
        var result = _customerService.GetCustomers(1, 10, "", "Name").ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("A Customer", result[0].Name);
        Assert.AreEqual("B Customer", result[1].Name);
    }

    [TestMethod]
    public void GetCustomers_ReturnsFilteredAndSortedCustomers_WhenBothApplied()
    {
        // Given
        var customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "C Customer", Status = "Inactive", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "A Customer", Status = "Active", CreatedAt = DateTime.Now },
            new Customer { Id = Guid.NewGuid(), Name = "B Customer", Status = "Active", CreatedAt = DateTime.Now },
        };

        _customerDaoMock.Setup(x => x.GetCustomers(1, 10, "Active", "Name")).Returns(customers.Where(c => c.Status == "Active").OrderBy(c => c.Name).ToList());

        // When
        var result = _customerService.GetCustomers(1, 10, "Active", "Name").ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("A Customer", result[0].Name);
        Assert.AreEqual("B Customer", result[1].Name);
    }

    [TestMethod]
    public void GetCustomers_ReturnsEmpty_WhenFilterDoesNotMatchAnyCustomer()
    {
        // Given
        _customerDaoMock.Setup(x => x.GetCustomers(1, 10, "Nonexistent", "")).Returns(new List<Customer>());

        // When
        var result = _customerService.GetCustomers(1, 10, "Nonexistent", "").ToList();

        // Then
        Assert.AreEqual(0, result.Count);
    }
}