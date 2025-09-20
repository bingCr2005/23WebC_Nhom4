using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using th_nhom01.Configurations;

namespace th_nhom01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigTestController : ControllerBase
    {
        private readonly MyAppSetting _settings;

        public ConfigTestController(IOptions<MyAppSetting> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet("maxfilesize")]
        public IActionResult GetMaxFileSize()
        {
            return Ok($"MaxFileSize = {_settings.MaxFileSize}");
        }

        [HttpGet("bannedips")]
        public IActionResult GetBannedIPs()
        {
            return Ok(_settings.BannedIPs);
        }
    }
}
