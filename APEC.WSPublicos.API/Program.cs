using APEC.WS.Aplicacion.Interfaces;
using APEC.WS.Aplicacion.Servicios;
using APEC.WS.Infrastructura.Data;
using APEC.WS.Infrastructura.Modelos;
using APEC.WSPublicos.API;
using APEC.WSPublicos.Aplicacion.Interfaces;
using APEC.WSPublicos.Aplicacion.Servicios;
using Microsoft.EntityFrameworkCore;
using SoapCore;
using SoapCore.Extensibility;

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
builder.Services.AddScoped<IInflacionServiceSoap, InflacionServiceSoap>();

// Registrar transformador
builder.Services.AddSingleton<IFaultExceptionTransformer, CustomFaultExceptionTransformer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configuración SOAP
((IApplicationBuilder)app).UseSoapEndpoint<ITasaCambioServiceSoap>("/TasaCambio.asmx", new SoapCore.SoapEncoderOptions(), SoapSerializer.XmlSerializer);
((IApplicationBuilder)app).UseSoapEndpoint<IInflacionServiceSoap>("/Inflacion.asmx", new SoapCore.SoapEncoderOptions(), SoapSerializer.XmlSerializer);

// Middleware de registro de uso
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/api") ||
        context.Request.Path.StartsWithSegments("/TasaCambio.asmx") ||
        context.Request.Path.StartsWithSegments("/Inflacion.asmx"))
    {
        using (var scope = context.RequestServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.RegistrosUso.Add(new RegistroUsoServicio
            {
                NombreServicio = context.Request.Path,
                FechaInvocacion = DateTime.UtcNow
            });
            await dbContext.SaveChangesAsync();
        }
    }
    await next();
});

app.MapControllers();

app.Run();