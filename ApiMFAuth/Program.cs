
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddCors(options => options.AddPolicy("AllowAll", builder => { builder.WithOrigins("*", "https://localhost", "http://localhost", "http://homologacao.gsw.com.br").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); }));

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

//Este comando já esta "descontinuado" portanto deixei aqui comentado, utilizar o "AddMicrosoftIdentityWebApiAuthentication" no lugar 
//builder.Services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme).AddAzureADBearer(options => configuration.Bind("AzureActiveDirectory", options));

// Sign-in users with the Microsoft identity platform
builder.Services.AddMicrosoftIdentityWebApiAuthentication(configuration, "AzureActiveDirectory");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC MULTI FACTOR AUTHENTICATION V1"));
}

app.UseRouting();


app.UseCors(x => x
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader());

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
