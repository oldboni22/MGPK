using MGPK.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

var app = builder.Build();




app.Run();