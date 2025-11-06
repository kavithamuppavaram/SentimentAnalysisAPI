using SentimentAnalysis;

using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>()
    .FromFile("SentimentModel.mlnet");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapPost("/predict",
    async (PredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput> predictionEnginePool, SentimentModel.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));
//var result = PredictionEnginePool.Predict(input);


app.Run();

