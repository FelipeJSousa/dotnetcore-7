using dotnetcore_7.Configuration;

var _builder = WebApplication.CreateBuilder(args);
var _configuration = _builder.Configuration;

_builder.Services.AddServices(_configuration);

var _app = _builder.Build();

_app.UseWebApplication();

_app.Run();