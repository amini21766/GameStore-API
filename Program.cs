var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Hamid Welcome to C# Language's Code! didi you got it");

app.Run();
