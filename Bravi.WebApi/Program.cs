using Bravi.Data.Database.Context;
using Bravi.WebApi.Mapper;
using Bravi.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(Environment.GetEnvironmentVariable("DefaultConnection") ?? builder.Configuration.GetConnectionString("DefaultConnection")); 
});
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<ContatoService>();
builder.Services.AddScoped<ContatoTipoService>();  
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();
}

app.Run();
