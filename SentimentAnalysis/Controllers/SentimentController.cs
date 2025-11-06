//using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using SentimentAnalysis.Models;
using SentimentAnalysis.Services;
using SentimentAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace SentimentAnalysis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentimentController : ControllerBase
    {
        //private readonly SentimentService _sentimentService;

        //public SentimentController()
        //{
        //    _sentimentService = new SentimentService();
        //}

        [HttpPost]
        public IActionResult AnalyzeSentiment([FromBody] SentimentInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
                return BadRequest("Text input is required.");
            SentimentModel.ModelInput inputText = new SentimentModel.ModelInput{ Col0 = input.Text };
            var result = SentimentModel.Predict(inputText);
            //var prediction = _sentimentService.PredictSentiment(input.Text);
            return Ok(new
            {
                Text = input.Text,
                IsPositive = result.PredictedLabel  == 1 ? "true": "false"
        });
        }
    }
}
