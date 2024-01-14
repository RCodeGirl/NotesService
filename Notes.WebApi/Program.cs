using Notes.Persistence;
using Notes.Application.Common.Mappings;
using System.Reflection;
using Notes.Application.Interfaces;
using Notes.Application;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<NotesDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception)
	{
		throw;
	}
}
builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
});
builder.Services.AddAplication();
builder.Services.AddPersistence(config);
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	});
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapGet("/", () => "Hello World!");

app.Run();
