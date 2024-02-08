using Chat_MongoDB.Data;
using Chat_MongoDB.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Fügen Sie den MongoDbContext als Dienst hinzu
builder.Services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(builder.Configuration["MongoDbSettings:ConnectionString"], builder.Configuration["MongoDbSettings:DatabaseName"]));

// Weitere Dienste hinzufügen
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Konfigurieren Sie die HTTP-Anforderungspipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
