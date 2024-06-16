using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Services.Brinde;
using api.Services.Coleta;
using api.Services.EcoPonto;
using api.Services.Utilizador;
using api.Repository.Brinde;
using api.Repository.Coleta;
using api.Repository.EcoPonto;
using api.Repository.Utilizador;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal")); //ConexaoLocal ou ConexaoSomee
});



builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();
builder.Services.AddScoped<IEcoPontoService, EcoPontoService>();
builder.Services.AddScoped<IColetaService, ColetaService>();
builder.Services.AddScoped<IBrindeService, BrindeService>();

builder.Services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
builder.Services.AddScoped<IEcoPontoRepository, EcoPontoRepository>();
builder.Services.AddScoped<IColetaRepository, ColetaRepository>();
builder.Services.AddScoped<IBrindeRepository, BrindeRepository>();




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

