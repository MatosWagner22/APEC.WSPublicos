using APEC.WS.Aplicacion.Interfaces;
using APEC.WS.Aplicacion.Servicios;
using APEC.WS.Infrastructura.Data;
using APEC.WS.Infrastructura.Modelos;
using Microsoft.EntityFrameworkCore;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios de Application
builder.Services.AddScoped<ITasaCambioService, TasaCambioService>();

// Registrar servicios de Application UDDI
builder.Services.AddScoped<ITasaCambioServiceSoap, TasaCambioServiceSoap>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Middleware SOAP (con parámetros explícitos)
((IApplicationBuilder)app).UseSoapEndpoint<ITasaCambioServiceSoap>(
    path: "/TasaCambio.asmx",
    encoder: new SoapEncoderOptions(),
    serializer: SoapSerializer.XmlSerializer
);

// Middleware de registro de uso
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/api") ||
        context.Request.Path.StartsWithSegments("/TasaCambio.asmx"))
    {
        var dbContext = context.RequestServices.GetRequiredService<AppDbContext>();
        dbContext.RegistrosUso.Add(new RegistroUsoServicio
        {
            NombreServicio = context.Request.Path,
            FechaInvocacion = DateTime.UtcNow
        });
        await dbContext.SaveChangesAsync();
    }
    await next();
});

app.MapControllers();

app.Run();