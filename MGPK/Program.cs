using MGPK.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config
        .WriteTo.Console()
        .WriteTo.File("logs/.log"));

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();