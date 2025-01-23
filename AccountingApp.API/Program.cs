using AccountingApp.API.Hubs;
using AccountingApp.BLL.Interfaces;
using AccountingApp.BLL.Services;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DAL.Repositories;
using AccountingApp.DB.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddDbContext<MainContext>(options => {
	options.UseNpgsql(connectionString);
	// Avoids a loop ParentObject { ChildObject { ParentObject {...} } }
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers()
	// Avoids a loop ParentObject { ChildObject { ParentObject {...} } }
	.AddJsonOptions(options
		=> options.JsonSerializerOptions.ReferenceHandler
		= System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IDetailRepository, DetailRepository>();
builder.Services.AddScoped<IDetailService, DetailService>();

builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configures external access
builder.Services.AddCors(c => c.AddDefaultPolicy(options =>
{
	options.AllowCredentials()
	.AllowAnyHeader()
	.AllowAnyMethod()
	.WithOrigins("http://localhost:4200");
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

// Hubs
app.MapHub<DetailHub>("/hub/Detail");

app.Run();
