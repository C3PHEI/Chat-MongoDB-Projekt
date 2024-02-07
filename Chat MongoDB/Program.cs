using Chat_MongoDB.Data;

var builder = WebApplication.CreateBuilder(args);

// Fügen Sie den MongoDbContext als Dienst hinzu
builder.Services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(builder.Configuration["MongoDbSettings:ConnectionString"], builder.Configuration["MongoDbSettings:DatabaseName"]));

// Weitere Dienste hinzufügen
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
