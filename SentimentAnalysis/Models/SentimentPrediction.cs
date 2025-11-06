using Microsoft.ML.Data;
namespace SentimentAnalysis.Models
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsPositive { get; set; }
    }
}
