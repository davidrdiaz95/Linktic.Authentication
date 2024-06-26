using Linktic.Authentication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddControllers();
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureMapSectionConfiguration(builder.Configuration);
builder.Services.ConfigureDataBaseConnection(connectionString);
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureAuthentication(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(config =>
	{
		config.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		config.RoutePrefix = string.Empty;
	});
}

app.UseSwagger(options =>
{
	options.SerializeAsV2 = true;
});
app.UseCors("MyOrigin");
app.UseHttpsRedirection();

app.UseErrorHanldinMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
