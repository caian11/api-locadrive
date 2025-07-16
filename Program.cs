using Microsoft.EntityFrameworkCore;
using api_teste.Services;
using Microsoft.AspNetCore.Mvc;
using api_teste.DataContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddDataAnnotationsLocalization();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ADICIONE AQUI OS SERVICES
builder.Services.AddScoped<VeiculoService>();
builder.Services.AddScoped<SeguroService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<LocacaoService>();


// 1) Definir pol�tica de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2) Registra o middleware de CORS antes de UseAuthorization
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
