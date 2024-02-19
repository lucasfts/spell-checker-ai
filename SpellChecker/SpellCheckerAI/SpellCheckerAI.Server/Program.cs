using SpellCheckerAI.Server.Config;
using SpellCheckerAI.Server.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddChatGptHttpClient(configuration);
builder.Services.AddScoped<ISpellCheckerService, SpellCheckerService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/spell-check", async (string text, ISpellCheckerService service) =>
{
    return await service.GetSpellCheck(text);
})
.WithName("GetSpellCheck")
.WithOpenApi();

app.MapFallbackToFile("/index.html");

app.Run();