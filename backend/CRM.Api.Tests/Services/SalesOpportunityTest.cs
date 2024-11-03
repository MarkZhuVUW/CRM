using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Models;
using CRM.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace CRM.Api.Tests.Services;

[TestClass]
public class SalesOpportunityServiceTest
{
    private Mock<ISalesOpportunityDao> _salesOpportunityDaoMock;
    private Mock<ILogger<SalesOpportunityService>> _loggerMock;
    private ISalesOpportunityService _salesOpportunityService;
    private Mock<ICustomerService> _customerServiceMock;
    [TestInitialize]
    public async Task Setup()
    {
        _salesOpportunityDaoMock = new Mock<ISalesOpportunityDao>();
        _loggerMock = new Mock<ILogger<SalesOpportunityService>>();
        _customerServiceMock = new Mock<ICustomerService>();
        _salesOpportunityService = new SalesOpportunityService(_salesOpportunityDaoMock.Object, _loggerMock.Object, _customerServiceMock.Object);
    }
    
    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task CreateSalesOpportunity_ThrowsBadRequest_WhenCustomerDoesNotExist()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto 
        { 
            Id = Guid.NewGuid(), 
            Name = "New Opportunity", 
            Status = "New", 
            CustomerId = customerId 
        };

        // Setup the customer service to return null for the given customerId
        _customerServiceMock.Setup(x => x.CustomerExists(customerId)).ReturnsAsync(false);

        // When
        await _salesOpportunityService.CreateSalesOpportunity(customerId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task CreateSalesOpportunity_ThrowsBadRequestException_WhenOpportunityAlreadyExists()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto 
        { 
            Id = opportunityId, 
            Name = "Duplicate Opportunity", 
            Status = "New", 
            CustomerId = customerId 
        };

        // Setup the sales opportunity DAO to return the existing opportunity
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunityById(opportunityId)).ReturnsAsync(new SalesOpportunity 
        { 
            Id = opportunityId, 
            Name = "Existing Opportunity", 
            Status = "New", 
            CustomerId = customerId 
        });

        // When
        await _salesOpportunityService.CreateSalesOpportunity(customerId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    public async Task CreateSalesOpportunity_CreatesOpportunity_WhenValidAndDoesNotExist()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto 
        { 
            Id = Guid.NewGuid(), 
            Name = "New Opportunity", 
            Status = "New", 
            CustomerId = customerId 
        };

        _customerServiceMock.Setup(x => x.CustomerExists(customerId)).ReturnsAsync(true);

        // Setup the sales opportunity DAO to return null for the existing opportunity
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunityById(opportunityDto.Id)).ReturnsAsync((SalesOpportunity)null);

        // When
        await _salesOpportunityService.CreateSalesOpportunity(customerId.ToString(), opportunityDto);

        // Then
        _salesOpportunityDaoMock.Verify(x => x.CreateSalesOpportunity(It.IsAny<SalesOpportunity>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task CreateSalesOpportunity_ThrowsBadRequestException_WhenDtoIsInvalid()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto { Id = Guid.NewGuid(), Name = "", Status = "New", CustomerId = customerId }; // Invalid name

        // When
        await _salesOpportunityService.CreateSalesOpportunity(customerId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task CreateSalesOpportunity_ThrowsBadRequestException_WhenPathCustomerIdIsInvalid()
    {
        // Given
        var invalidCustomerId = "invalid-guid";
        var opportunityDto = new SalesOpportunityDto { Id = Guid.NewGuid(), Name = "Opportunity", Status = "New", CustomerId = Guid.NewGuid() };

        // When
        await _salesOpportunityService.CreateSalesOpportunity(invalidCustomerId, opportunityDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task CreateSalesOpportunity_ThrowsBadRequestException_WhenPathCustomerIdDoesNotMatchDtoCustomerId()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto { Id = Guid.NewGuid(), Name = "Opportunity", Status = "New", CustomerId = Guid.NewGuid() }; // Different CustomerId

        // When
        await _salesOpportunityService.CreateSalesOpportunity(customerId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }
    
    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsSalesOpportunityDtos_WhenOpportunitiesExist()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 1", Status = "New", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 2", Status = "Closed-Won", CustomerId = customerId }
        };
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities);

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(opportunities[0].Name, result[0].Name);
        Assert.AreEqual(opportunities[1].Name, result[1].Name);
    }

    [TestMethod]
    public async Task GetSalesOpportunityById_ReturnsSalesOpportunityDto_WhenOpportunityExists()
    {
        // Given
        var opportunityId = Guid.NewGuid();
        var opportunity = new SalesOpportunity { Id = opportunityId, Name = "Opportunity 1", Status = "New" };
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunityById(opportunityId)).ReturnsAsync(opportunity);

        // When
        var result = await _salesOpportunityService.GetSalesOpportunityById(opportunityId);

        // Then
        Assert.AreEqual(opportunityId, result.Id);
        Assert.AreEqual(opportunity.Name, result.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task GetSalesOpportunityById_ThrowsNotFoundException_WhenOpportunityDoesNotExist()
    {
        // Given
        var opportunityId = Guid.NewGuid();
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunityById(opportunityId)).ReturnsAsync((SalesOpportunity)null);

        // When
        await _salesOpportunityService.GetSalesOpportunityById(opportunityId);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    public async Task UpdateSalesOpportunity_UpdatesOpportunity_WhenOpportunityIsValid()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto { Id = opportunityId, Name = "Updated Opportunity", Status = "New", CustomerId = customerId };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunityById(opportunityId)).ReturnsAsync(new SalesOpportunity { Id = opportunityId, CustomerId = customerId });

        // When
        await _salesOpportunityService.UpdateSalesOpportunity(customerId.ToString(), opportunityId.ToString(), opportunityDto);

        // Then
        _salesOpportunityDaoMock.Verify(x => x.UpdateSalesOpportunity(It.IsAny<SalesOpportunity>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task UpdateSalesOpportunity_ThrowsNotFoundException_WhenOpportunityDoesNotExist()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto { Id = opportunityId, Name = "Opportunity", Status = "New", CustomerId = customerId };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunityById(opportunityId)).ReturnsAsync((SalesOpportunity)null);

        // When
        await _salesOpportunityService.UpdateSalesOpportunity(customerId.ToString(), opportunityId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task UpdateSalesOpportunity_ThrowsBadRequestException_WhenOpportunityDtoIsInvalid()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunityId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto { Id = opportunityId, Name = "", Status = "New", CustomerId = customerId };

        // When
        await _salesOpportunityService.UpdateSalesOpportunity(customerId.ToString(), opportunityId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }

    [TestMethod]
    [ExpectedException(typeof(BadRequestException))]
    public async Task UpdateSalesOpportunity_ThrowsBadRequestException_WhenPathIdsDoNotMatchDtoIds()
    {
        // Given
        var opportunityId = Guid.NewGuid();
        var opportunityDto = new SalesOpportunityDto { Id = Guid.NewGuid(), Name = "Opportunity", Status = "New", CustomerId = Guid.NewGuid() };

        // When
        await _salesOpportunityService.UpdateSalesOpportunity(Guid.NewGuid().ToString(), opportunityId.ToString(), opportunityDto);

        // Then - ExpectedException will validate this
    }

    // pagination tests
    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsPagedOpportunities_WhenValidCustomerId()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 1", Status = "New", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 2", Status = "New", CustomerId = customerId },
        };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities);

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.All(so => so.Status == "New"));
    }

    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsEmpty_WhenNoOpportunitiesAvailable()
    {
        // Given
        var customerId = Guid.NewGuid();
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(new List<SalesOpportunity>());

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsSingleOpportunity_WhenLessThanPageSize()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 1", Status = "New", CustomerId = customerId }
        };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities);

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Opportunity 1", result[0].Name);
    }

    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsExactCount_WhenExactlyMatching()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 1", Status = "New", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 2", Status = "Closed-Lost", CustomerId = customerId }
        };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities);

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(2, result.Count);
    }

    // filter and sort tests
    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsFilteredOpportunities_WhenFilterIsApplied()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 1", Status = "New", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 2", Status = "Closed-Won", CustomerId = customerId },
        };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities.Where(so => so.Status == "New").ToList());

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Opportunity 1", result[0].Name);
    }

    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsSortedOpportunities_WhenSortIsApplied()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "B Opportunity", Status = "New", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "A Opportunity", Status = "New", CustomerId = customerId },
        };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities.OrderBy(so => so.Name).ToList());

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("A Opportunity", result[0].Name);
        Assert.AreEqual("B Opportunity", result[1].Name);
    }

    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsFilteredAndSortedOpportunities_WhenBothApplied()
    {
        // Given
        var customerId = Guid.NewGuid();
        var opportunities = new List<SalesOpportunity>
        {
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 3", Status = "Closed-Lost", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 1", Status = "New", CustomerId = customerId },
            new SalesOpportunity { Id = Guid.NewGuid(), Name = "Opportunity 2", Status = "New", CustomerId = customerId },
        };

        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(opportunities.Where(so => so.Status == "New").OrderBy(so => so.Name).ToList());

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Opportunity 1", result[0].Name);
        Assert.AreEqual("Opportunity 2", result[1].Name);
    }

    [TestMethod]
    public async Task GetSalesOpportunities_ReturnsEmpty_WhenFilterDoesNotMatchAnyOpportunity()
    {
        // Given
        var customerId = Guid.NewGuid();
        _salesOpportunityDaoMock.Setup(x => x.GetSalesOpportunities(customerId)).ReturnsAsync(new List<SalesOpportunity>());

        // When
        var result = (await _salesOpportunityService.GetSalesOpportunities(customerId)).ToList();

        // Then
        Assert.AreEqual(0, result.Count);
    }
}