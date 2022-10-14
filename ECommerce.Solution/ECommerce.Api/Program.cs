using ECommerce.Application;
using System.Runtime.Loader;
using MediatR;

var files = Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "ECommerce*.dll");

var assemblies = files
       .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Scan(p => p.FromAssemblies(assemblies)
        .AddClasses()
        .AsMatchingInterface());

builder.Services.AddMediatR(typeof(CQRSEntrypoint).Assembly);

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
