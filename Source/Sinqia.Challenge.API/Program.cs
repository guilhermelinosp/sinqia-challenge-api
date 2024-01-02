using Sinqia.Challenge.API.Filters;
using Sinqia.Challenge.Application;
using Microsoft.OpenApi.Models;
using Sinqia.Challenge.Infrastructure.Contexts.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var services = builder.Services;

AttractionDbContextFactory.Create(configuration["SQLServer:ConnectionString"]!).Seed();

services.AddApplicationInjection(configuration);
services.AddCors(options =>
{
	options.AddPolicy("*",builder =>
	{
		builder
			.AllowAnyHeader()
			.AllowCredentials()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

services.AddScoped<ExceptionFilter>();
services.AddControllers(options => { options.Filters.AddService<ExceptionFilter>(); });
services.AddEndpointsApiExplorer();
services.AddHttpContextAccessor();
services.AddSwaggerGen(opt =>
{
	opt.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Sinqia Challenge API",
		Version = "v1",
		Description = "Welcome to the Sinqia Challenge API...",
		Contact = new OpenApiContact
		{
			Name = "Guilherme Lino",
			Email = "guilhermelinosp@gmail.com"
		}
	});
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	configuration.AddUserSecrets<Program>();
}
else
{
	app.UseHsts();
	app.UseExceptionHandler("/error");
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("*");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();