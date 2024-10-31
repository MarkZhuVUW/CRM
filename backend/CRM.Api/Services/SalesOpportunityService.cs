using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Models;
using Microsoft.Extensions.Logging;

namespace CRM.Api.Services
{
    public class SalesOpportunityService : ISalesOpportunityService
    {
        private readonly ISalesOpportunityDao _salesOpportunityDao;
        private readonly ILogger<SalesOpportunityService> _logger;

        public SalesOpportunityService(ISalesOpportunityDao salesOpportunityDao, ILogger<SalesOpportunityService> logger)
        {
            _salesOpportunityDao = salesOpportunityDao;
            _logger = logger;
        }

        public IEnumerable<SalesOpportunityDto> GetSalesOpportunities(Guid customerId)
        {
            _logger.LogInformation("GetSalesOpportunities started with: customerId={CustomerId}", customerId);
            
            var opportunities = _salesOpportunityDao.GetSalesOpportunities(customerId);
            var opportunityDtos = opportunities.Select(so => new SalesOpportunityDto 
            { 
                Id = so.Id,
                Name = so.Name,
                Status = so.Status,
                CustomerId = so.CustomerId,
                CreatedAt = so.CreatedAt, 
                UpdatedAt = so.UpdatedAt
            }).ToList();

            _logger.LogInformation("GetSalesOpportunities completed with result: {@OpportunityDtos}", opportunityDtos);
            return opportunityDtos;
        }

        public void UpdateSalesOpportunity(string pathCustomerId, string pathOpportunityId, SalesOpportunityDto opportunityDto)
        {
            _logger.LogInformation("UpdateSalesOpportunity started with: pathCustomerId={PathCustomerId}, pathOpportunityId={PathOpportunityId}, opportunityDto={@OpportunityDto}",
                pathCustomerId, pathOpportunityId, opportunityDto);

            var validationErrors = GetValidationErrors(opportunityDto);
            if (!Guid.TryParse(pathCustomerId, out var parsedPathCustomerId) || !Guid.TryParse(pathOpportunityId, out var parsedPathOpportunityId))
            {
                throw new BadRequestException("path customer id or path opportunity id is invalid. pathCustomerId = " + pathCustomerId + " pathOpportunityId = " + pathOpportunityId);
            }

            if (!parsedPathCustomerId.Equals(opportunityDto.CustomerId) ||
                !parsedPathOpportunityId.Equals(opportunityDto.Id))
            {
                throw new BadRequestException(
                    "path customer id or path opportunity id do not match the value in dto. pathCustomerId = " + 
                    pathCustomerId + " pathOpportunityId = " + 
                    pathOpportunityId + " dto = " + 
                    opportunityDto
                );
            }
            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Sales Opportunity not valid: " + opportunityDto + string.Join(", ", validationErrors));
            }

            var opportunity = _salesOpportunityDao.GetSalesOpportunityById(opportunityDto.Id);
            if (opportunity == null)
            {
                throw new NotFoundException("Sales Opportunity not found: " + opportunityDto.Id);
            }
            
            _salesOpportunityDao.UpdateSalesOpportunity(new SalesOpportunity
            {
                Id = opportunityDto.Id,
                Name = opportunityDto.Name,
                Status = opportunityDto.Status,
                CustomerId = opportunityDto.CustomerId,
                CreatedAt = opportunity.CreatedAt, 
                UpdatedAt = DateTime.UtcNow 
            });

            _logger.LogInformation("UpdateSalesOpportunity completed successfully for opportunityId={OpportunityId}", opportunityDto.Id);
        }

        public SalesOpportunityDto GetSalesOpportunityById(Guid id)
        {
            _logger.LogInformation("GetSalesOpportunityById started with: id={Id}", id);

            var salesOpportunity = _salesOpportunityDao.GetSalesOpportunityById(id);
            if (salesOpportunity == null)
            {
                throw new NotFoundException("Sales Opportunity not found: " + id);
            }

            var opportunityDto = new SalesOpportunityDto
            {
                Id = salesOpportunity.Id,
                Name = salesOpportunity.Name,
                Status = salesOpportunity.Status,
                CustomerId = salesOpportunity.CustomerId,
                CreatedAt = salesOpportunity.CreatedAt, 
                UpdatedAt = salesOpportunity.UpdatedAt
            };

            _logger.LogInformation("GetSalesOpportunityById completed with result: {@OpportunityDto}", opportunityDto);
            return opportunityDto;
        }

        private static List<string> GetValidationErrors(SalesOpportunityDto opportunityDto)
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(opportunityDto.Name))
            {
                validationErrors.Add("Sales Opportunity name cannot be empty.");
            }
            return validationErrors;
        }
    }
}