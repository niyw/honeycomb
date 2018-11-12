using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Configuration.Setter;

namespace NSB.ApiManagement.ApiMgtService.Controllers {
    //此Controller操作FileConfiguration.GlobalConfiguration,包括查询/更新
    [Route("admin/[controller]")]
    [ApiController]
    [Authorize]
    public class GlobalController : ControllerBase
    {
        private readonly IFileConfigurationRepository _repo;
        private readonly IFileConfigurationSetter _setter;
        private readonly IServiceProvider _provider;
        private readonly ILogger<GlobalController> _logger;

        public GlobalController(IFileConfigurationRepository repo, IFileConfigurationSetter setter, IServiceProvider provider, ILogger<GlobalController> logger) {
            _repo = repo;
            _setter = setter;
            _provider = provider;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            _logger.LogInformation("get demo log");
            var response = await _repo.Get();
            if (response.IsError) {
                return new BadRequestObjectResult(response.Errors);
            }
            return new OkObjectResult(response.Data.GlobalConfiguration);
        }
    }
}