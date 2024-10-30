using CRM.Api.Context;
using CRM.Api.Dao;
using CRM.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// daos
builder.Services.AddScoped<ICustomerDao, CustomerDao>();
builder.Services.AddScoped<ISalesOpportunityDao, SalesOpportunityDao>();
// services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISalesOpportunityService, SalesOpportunityService>();

var app = builder.Build();


// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CrmDbContext>();
        context.Database.Migrate(); // This applies any pending migrations
    }
    catch (Exception ex)
    {
        // Log the error or handle it as necessary
        // You can use a logging service or just log to the console for simplicity
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
