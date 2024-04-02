using POC.DOTNET.ASKBLUE.WEBAPI.REST.Configuration;

#region Builder Configuration

var builder = WebApplication.CreateBuilder(args);

#endregion

#region Configure Services

builder.Services.AddControllers();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddApiConfiguration();

builder.Services.AddSwaggerConfiguration();


var app = builder.Build();

#endregion

#region Configure Pipeline

app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

app.Run();

#endregion
