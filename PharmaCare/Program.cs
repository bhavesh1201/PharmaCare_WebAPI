using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PharmaCare;
using PharmaCare.Data;
using PharmaCare.Repository;
using PharmaCare.Repository.IRepository;
using Serilog;
using System.Reflection;
using System.Text;
using static PharmaCare.SwaggerControllerOrderAttribute;

var builder = WebApplication.CreateBuilder(args);
SwaggerControllerOrder<ControllerBase> swaggerControllerOrder = new SwaggerControllerOrder<ControllerBase>(Assembly.GetEntryAssembly());

// Add services to the container.



builder.Services.AddDbContext<PharmacyContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Added Connection String h


builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));  // By default all request is declined by http link , we have manually used the cors to allow request

builder.Services.AddAutoMapper(typeof(MappingConfig)); // Added new service for mapping infinite feilds


var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");  // Getting secret key value from json file
#region Services
//All the Services has been injected here
builder.Services.AddScoped<IDrugRepository,DrugRepository>();
builder.Services.AddScoped<ISuppilerRepository,SuppilerRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
#endregion

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer (x=>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };

}); // Authentication laga diya 


builder.Services.AddControllers().AddNewtonsoftJson(); // patch use krne ke liye addNewton use kia

Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/DrugLogs.txt",rollingInterval:RollingInterval.Infinite)
    .CreateLogger();  // Logges store kr rha hu is file main , jo new file infinite time main banegi aur level hai debug mtlb debug
                      // ke upper sare logs store honge





builder.Host.UseSerilog();  //DEFAULT LOGGER KI JHAGA SERILOG KA INSTINCT CHLA JAYGA  + added 3 packages


builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.OrderActionsBy((apiDesc) => $"{swaggerControllerOrder.SortKey(apiDesc.ActionDescriptor.RouteValues["controller"])}");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();  // added routing here
app.UseCors("MyPolicy");
//added my policy
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
