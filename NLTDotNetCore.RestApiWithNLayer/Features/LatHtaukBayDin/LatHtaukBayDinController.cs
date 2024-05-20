using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLTDotNetCore.RestApiWithNLayer.Models.LatHtaukBayDin;

namespace NLTDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {
        private async Task<LatHtaukBayDinModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LatHtaukBayDinModel>(jsonStr);
            return model!;
        }

        // api/LatHtaukBayDin/questions
        [HttpGet("questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.Questions);
        }

        [HttpGet("number-list")]
        public async Task<IActionResult> NumberList()
        {
            var model = await GetDataAsync();
            return Ok(model.NumberList);
        }

        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> Answer(int questionNo, int no)
        {
            var model = await GetDataAsync();
            return Ok(model.Answers.FirstOrDefault(x => x.QuestionNo == questionNo && x.AnswerNo == no));
        }
    }
}