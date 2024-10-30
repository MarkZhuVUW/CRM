using CRM.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Context
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOpportunity> SalesOpportunities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("customer");
        modelBuilder.Entity<SalesOpportunity>().ToTable("sales_opportunity");
        
        // Configure one-to-many relationship
        modelBuilder.Entity<SalesOpportunity>()
            .HasOne(so => so.Customer) // Each SalesOpportunity has one Customer
            .WithMany(c => c.SalesOpportunities) // A Customer can have many SalesOpportunities
            .HasForeignKey(so => so.CustomerId); // Specify the foreign key property
        
        // Add indexes for the Customer entity
        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Name) // Index on Name for filtering and sorting
            .HasDatabaseName("IX_Customers_Name");

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email) // Index on Email for filtering
            .HasDatabaseName("IX_Customers_Email");

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Status) // Index on Status for filtering
            .HasDatabaseName("IX_Customers_Status");

        // Add indexes for the SalesOpportunity entity
        modelBuilder.Entity<SalesOpportunity>()
            .HasIndex(so => so.Name) // Index on Name for filtering and sorting
            .HasDatabaseName("IX_SalesOpportunities_Name");

        modelBuilder.Entity<SalesOpportunity>()
            .HasIndex(so => so.Status) // Index on Status for filtering
            .HasDatabaseName("IX_SalesOpportunities_Status");

        modelBuilder.Entity<SalesOpportunity>()
            .HasIndex(so => so.CustomerId) // Index on CustomerId for joining and filtering
            .HasDatabaseName("IX_SalesOpportunities_CustomerId");
        
        // Hardcoded GUIDs for customers
        var customerIds = new[]
        {
            Guid.Parse("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"),
            Guid.Parse("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"),
            Guid.Parse("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"),
            Guid.Parse("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"),
            Guid.Parse("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"),
            Guid.Parse("abf58660-f942-4632-b76d-93174ee7ac41"),
            Guid.Parse("f748b8be-82f7-4ec0-86b7-8a5e35e94727"),
            Guid.Parse("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"),
            Guid.Parse("e0b94f78-2257-4964-a20c-6bc5149d1ae2"),
            Guid.Parse("efcfd745-6b30-4b41-8a6f-e779baf53175"),
            Guid.Parse("3c1c68e1-847f-4059-b9f8-184f92300959"),
            Guid.Parse("7328f51c-5e1b-4b57-9d64-b4817d4939d5"),
            Guid.Parse("3dfb1384-f037-41da-b84e-4d78fd67b13b"),
            Guid.Parse("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"),
            Guid.Parse("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"),
            Guid.Parse("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"),
            Guid.Parse("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"),
            Guid.Parse("e4eae6cb-79ed-41e1-b075-1db5a38b9647"),
            Guid.Parse("a2c7e550-bd9b-40fc-8b62-01c6270e18be"),
            Guid.Parse("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"),
            Guid.Parse("d4c0c1f7-d8ed-478f-b0b7-2e53edbdf7c7"),
        };

        // Hardcoded data for customers
        modelBuilder.Entity<Customer>().HasData(new[]
        {
            new Customer { Id = customerIds[0], Name = "John Doe", Email = "john@example.com", PhoneNumber = "1234567890", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[1], Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "0987654321", Status = "Lead", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[2], Name = "Bob Johnson", Email = "bob@example.com", PhoneNumber = "1112223333", Status = "Non-Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[3], Name = "Alice Williams", Email = "alice@example.com", PhoneNumber = "4445556666", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[4], Name = "Charlie Brown", Email = "charlie@example.com", PhoneNumber = "7778889999", Status = "Lead", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[5], Name = "David Miller", Email = "david@example.com", PhoneNumber = "1231231234", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[6], Name = "Emma Davis", Email = "emma@example.com", PhoneNumber = "4564564567", Status = "Non-Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[7], Name = "Frank Wilson", Email = "frank@example.com", PhoneNumber = "7897897890", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[8], Name = "Grace Lee", Email = "grace@example.com", PhoneNumber = "2342342345", Status = "Lead", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[9], Name = "Henry Thomas", Email = "henry@example.com", PhoneNumber = "5675675678", Status = "Non-Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[10], Name = "Isabella Moore", Email = "isabella@example.com", PhoneNumber = "8908908901", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[11], Name = "Jack Taylor", Email = "jack@example.com", PhoneNumber = "1231234567", Status = "Lead", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[12], Name = "Liam Anderson", Email = "liam@example.com", PhoneNumber = "9876543210", Status = "Non-Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[13], Name = "Mia Thomas", Email = "mia@example.com", PhoneNumber = "6543210987", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[14], Name = "Noah Garcia", Email = "noah@example.com", PhoneNumber = "3456789012", Status = "Lead", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[15], Name = "Olivia Martinez", Email = "olivia@example.com", PhoneNumber = "4567890123", Status = "Non-Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[16], Name = "Sophia Hernandez", Email = "sophia@example.com", PhoneNumber = "5678901234", Status = "Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[17], Name = "Lucas Lopez", Email = "lucas@example.com", PhoneNumber = "6789012345", Status = "Lead", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[18], Name = "Ethan Walker", Email = "ethan@example.com", PhoneNumber = "7890123456", Status = "Non-Active", CreatedAt = DateTime.UtcNow },
            new Customer { Id = customerIds[19], Name = "Ava Hall", Email = "ava@example.com", PhoneNumber = "8901234567", Status = "Active", CreatedAt = DateTime.UtcNow },
        });

        // Hardcoded GUIDs for sales opportunities
        var opportunityIds = new[]
        {
            Guid.Parse("4a69bd10-c44c-4b78-92f0-8c3c548fe60e"),
            Guid.Parse("b7e76f0b-d97c-42e0-bccc-665c74064c62"),
            Guid.Parse("9f0dc78e-3c84-4b89-a4e5-41ef0e59f58e"),
            Guid.Parse("0a844944-93e9-4d79-a0ef-eaa99d1e13d7"),
            Guid.Parse("8c7e72b5-3b58-4f80-bc77-74a52c6e3ff3"),
            Guid.Parse("e67cbbfc-7320-4574-bcc1-b5913b0b14ef"),
            Guid.Parse("654f7b73-c502-49b1-95d3-68f3d7c9d2e0"),
            Guid.Parse("66db1a29-c72c-4878-b89c-b1d4a949c124"),
            Guid.Parse("1200f76e-98f4-4ac1-a83f-efc3743fc6a2"),
            Guid.Parse("7729cdb7-10b6-4f71-b3ef-3e4f12e0be6b"),
            Guid.Parse("ff562ca5-e81b-45a7-90e8-54cde1c5da68"),
            Guid.Parse("e9792be3-9b36-4c41-b0e5-2c8d6fc028e4"),
            Guid.Parse("dd90b460-65e5-403e-9b52-6b88f3f0542a"),
            Guid.Parse("b04c3a47-672f-44c3-bf7f-f4f80be417cf"),
            Guid.Parse("1b1cbf8c-14de-433c-bfd2-18665c0d8fd0"),
            Guid.Parse("0d03c8bc-59c2-4fc4-b1a5-58fd2ff98f0e"),
            Guid.Parse("b65c049f-b1bb-49c9-9b4e-bfa9535da204"),
            Guid.Parse("d14efde3-b5d0-4f74-99d1-94f4f3aa2bb1"),
            Guid.Parse("37b8ed83-ec52-46e6-9d58-688f0ee87ad7"),
            Guid.Parse("fc21f384-fb79-4f4e-bf85-053b67e76b78"),
            Guid.Parse("f4935788-2e6f-4e96-abe4-c45e78eb0c56"),
        };

        // Hardcoded data for sales opportunities
        modelBuilder.Entity<SalesOpportunity>().HasData(new[]
        {
            new SalesOpportunity { Id = opportunityIds[0], Name = "Opportunity 1", Status = "New", CustomerId = customerIds[0] },
            new SalesOpportunity { Id = opportunityIds[1], Name = "Opportunity 2", Status = "Closed Won", CustomerId = customerIds[1] },
            new SalesOpportunity { Id = opportunityIds[2], Name = "Opportunity 3", Status = "Lost", CustomerId = customerIds[2] },
            new SalesOpportunity { Id = opportunityIds[3], Name = "Opportunity 4", Status = "New", CustomerId = customerIds[3] },
            new SalesOpportunity { Id = opportunityIds[4], Name = "Opportunity 5", Status = "Closed Won", CustomerId = customerIds[4] },
            new SalesOpportunity { Id = opportunityIds[5], Name = "Opportunity 6", Status = "New", CustomerId = customerIds[5] },
            new SalesOpportunity { Id = opportunityIds[6], Name = "Opportunity 7", Status = "Closed Lost", CustomerId = customerIds[6] },
            new SalesOpportunity { Id = opportunityIds[7], Name = "Opportunity 8", Status = "New", CustomerId = customerIds[7] },
            new SalesOpportunity { Id = opportunityIds[8], Name = "Opportunity 9", Status = "Closed Won", CustomerId = customerIds[8] },
            new SalesOpportunity { Id = opportunityIds[9], Name = "Opportunity 10", Status = "New", CustomerId = customerIds[9] },
            new SalesOpportunity { Id = opportunityIds[10], Name = "Opportunity 11", Status = "Closed Won", CustomerId = customerIds[10] },
            new SalesOpportunity { Id = opportunityIds[11], Name = "Opportunity 12", Status = "New", CustomerId = customerIds[11] },
            new SalesOpportunity { Id = opportunityIds[12], Name = "Opportunity 13", Status = "Lost", CustomerId = customerIds[12] },
            new SalesOpportunity { Id = opportunityIds[13], Name = "Opportunity 14", Status = "New", CustomerId = customerIds[13] },
            new SalesOpportunity { Id = opportunityIds[14], Name = "Opportunity 15", Status = "Closed Won", CustomerId = customerIds[14] },
            new SalesOpportunity { Id = opportunityIds[15], Name = "Opportunity 16", Status = "Closed Lost", CustomerId = customerIds[15] },
            new SalesOpportunity { Id = opportunityIds[16], Name = "Opportunity 17", Status = "New", CustomerId = customerIds[16] },
            new SalesOpportunity { Id = opportunityIds[17], Name = "Opportunity 18", Status = "New", CustomerId = customerIds[17] },
            new SalesOpportunity { Id = opportunityIds[18], Name = "Opportunity 19", Status = "Closed Won", CustomerId = customerIds[18] },
            new SalesOpportunity { Id = opportunityIds[19], Name = "Opportunity 20", Status = "New", CustomerId = customerIds[19] },
        });
    }

        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options) { }
    }
}