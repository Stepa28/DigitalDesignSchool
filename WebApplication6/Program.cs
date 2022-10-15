using PrivateLibrary;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/WordsCouturier", (string[] allText) => new WordsCounter().WordsCounterFromPathFileParallel(allText));


app.Run();