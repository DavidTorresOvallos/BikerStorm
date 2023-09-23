using BikerStorm.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using BikerStorm.Repository.Contrato;
using BikerStorm.Repository.Implementacion;
using BikerStorm.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BikerStormContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
