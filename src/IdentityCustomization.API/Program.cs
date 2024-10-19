using IdentityCustomization.API.Constants;
using IdentityCustomization.API.DependencyInjection;
using IdentityCustomization.API.Filters;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers(options => options.Filters.AddService<NotificationFilter>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseCors(CorsPoliciesNamesConstants.CorsPolicy);
app.MigrateDatabase();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
