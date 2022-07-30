using System.Web.Http;
using System.Web.Http.SelfHost;
using Microsoft.EntityFrameworkCore;
using WebmotorsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<WebmotorsContext>(opt =>
    opt.UseInMemoryDatabase("WebmotorsList"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  //app.UseSwagger();
  //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

//Self Host
var config = new HttpSelfHostConfiguration("http://localhost:8080");

config.Routes.MapHttpRoute(
    "API Default", "api/{controller}/{id}",
    new { id = RouteParameter.Optional });

using (HttpSelfHostServer server = new HttpSelfHostServer(config))
{
  server.OpenAsync().Wait();
  Console.WriteLine("Press Enter to quit.");
  Console.ReadLine();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
