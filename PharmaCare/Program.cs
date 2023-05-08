using Microsoft.EntityFrameworkCore;
using PharmaCare;
using PharmaCare.Data;
using PharmaCare.Repository;
using PharmaCare.Repository.IRepository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<PharmacyContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // ConnectionString Add krdia hai

builder.Services.AddAutoMapper(typeof(MappingConfig)); // Added new service for mapping infinite feilds


builder.Services.AddScoped<IDrugRepository,DrugRepository>();



builder.Services.AddControllers().AddNewtonsoftJson(); // patch use krne ke liye addNewton use kia

Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/DrugLogs.txt",rollingInterval:RollingInterval.Infinite)
    .CreateLogger();  // Logges store kr rha hu is file main , jo new file infinite time main banegi aur level hai debug mtlb debug
                      // ke upper sare logs store honge



builder.Host.UseSerilog();  //DEFAULT LOGGER KI JHAGA SERILOG KA INSTINCT CHLA JAYGA  + added 3 packages

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
