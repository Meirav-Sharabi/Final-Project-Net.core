using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Weight_Watchers.data;
using Project_Net.core.config;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.ConfigurationService();

builder.Host.UseSerilog((context, configuration) =>
{

    ///����� �� ������ �������d 
    configuration.ReadFrom.Configuration(context.Configuration);

});

builder.Services.AddDbContext<Weight_Watchers_Context>(option =>
{
    //������ DB ������ ����� 
    option.UseSqlServer(configuration.GetConnectionString("Weight_WatchersConnectionString"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();


app.UseHttpsRedirection();

app.UseAuthorization();
//���� ����� ��� �������� 
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.MapControllers();

app.UseMiddleware(typeof(MiddleWare));


app.Run();
