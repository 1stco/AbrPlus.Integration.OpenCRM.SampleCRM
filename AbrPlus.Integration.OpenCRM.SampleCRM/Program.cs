using AbrPlus.Cloud.Stream.Hubs;
using AbrPlus.Integration.OpenCRM.SampleCRM.DI;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(t =>
{
    t.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
}).AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(exceptionHandler =>
{
    exceptionHandler.Run(async context =>
    {
        await HandleException(context.Features.Get<IExceptionHandlerFeature>().Error, context);
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<OpenCRMHub>("/OpenCRMHub");


app.Run();



async Task HandleException(Exception error, HttpContext context)
{
    throw new NotImplementedException();
}