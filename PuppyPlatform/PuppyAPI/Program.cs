using Microsoft.EntityFrameworkCore;
using PuppyAPI.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in for enum visualization

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PuppyAPIContext")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();