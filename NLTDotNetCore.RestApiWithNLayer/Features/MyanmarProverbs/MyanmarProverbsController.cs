using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NLTDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<MMProverbsModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
            var model = JsonConvert.DeserializeObject<MMProverbsModel>(jsonStr);
            return model!;
        }

        [HttpGet("title")]
        public async Task<IActionResult> Title()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("proverbName/{titleId}")]
        public async Task<IActionResult> Proverbs(int titleId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs.Where(x => x.TitleId == titleId)
                .Select(x => new { x.TitleId, x.ProverbId, x.ProverbName }));
        }

        [HttpGet("proverbDetail/{titleId}/{proverbId}")]
        public async Task<IActionResult> Proverb(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId));
        }
    }
}