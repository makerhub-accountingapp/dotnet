using AccountingApp.DB.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddDbContext<MainContext>(options => {
	options.UseNpgsql(connectionString);
	// To avoid a loop ParentObject { ChildObject { ParentObject {...} } }
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers()
	// To avoid a loop ParentObject { ChildObject { ParentObject {...} } }
	.AddJsonOptions(options
		=> options.JsonSerializerOptions.ReferenceHandler
		= System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
