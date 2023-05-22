using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PuppyAPI.Database;
using PuppyAPI.Model;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in for enum visualization


// Add services to the container.
// "Data Source=FemkeLenovo;Database=CAMP;Integrated Security=sspi; TrustServerCertificate=True; MultipleActiveResultSets=true"
var connectionString =
    $"Data Source={Environment.GetEnvironmentVariable("SERVER")};" +
    $" Database={Environment.GetEnvironmentVariable("DATABASE")};" +
    $" Integrated Security=sspy;" +
    $" TrustServerCertificate=True;" +
    $" MultipleActiveResultSets=true" +
    $" User Id={Environment.GetEnvironmentVariable("UID")};" +
    $" Password={Environment.GetEnvironmentVariable("PWD")};";
Console.WriteLine(connectionString); //TODO rm

builder.Services.AddDbContext<DatabaseContext>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("PuppyAPIContext")));
    options.UseSqlServer(connectionString)); //mssql?

builder.Services.Configure<JwtAuthenticationConfig>(builder.Configuration.GetSection("JwtAuthentication"));

//  Add authentication 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    //options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // global cors policy
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
                                            //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
        .AllowCredentials()); // allow credentials
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
