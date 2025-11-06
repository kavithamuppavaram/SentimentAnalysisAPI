using Microsoft.ML;
using System.Runtime.InteropServices;
using SentimentAnalysis.Models;
// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("702cd7f0-0574-4229-8889-a6a45eadfe4d")]



namespace SentimentAnalysis.Services
{
    public class SentimentService
    {
        private readonly PredictionEngine<SentimentInput, SentimentPrediction> _predictionEngine;

        public SentimentService()
        {
            var mlContext = new MLContext();
            var modelPath = Path.Combine(AppContext.BaseDirectory, "MLModel", "SentimentModel.zip");
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentInput, SentimentPrediction>(mlModel);
        }

        public SentimentPrediction PredictSentiment(string text)
        {
            var input = new SentimentInput { Text = text };
            return _predictionEngine.Predict(input);
        }
    }
}
