using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Configuration.Setter;

namespace NSB.ApiManagement.ApiMgtService.Controllers {
    [Route("admin/[controller]")]
    [ApiController]
    [Authorize]
    public class RerouteController : ControllerBase {
        private readonly IFileConfigurationRepository _repo;
        private readonly IFileConfigurationSetter _setter;
        private readonly IServiceProvider _provider;
        private readonly ILogger<RerouteController> _logger;
        public RerouteController(IFileConfigurationRepository repo, IFileConfigurationSetter setter, IServiceProvider provider, ILogger<RerouteController> logger) {
            _repo = repo;
            _setter = setter;
            _provider = provider;
            _logger = logger;
        }
        //读取所有ReRoutes
        [HttpGet]
        public async Task<IActionResult> Get() {
            _logger.LogInformation("get demo log");
            //对ReRoute对象操作是对FileConfiguration.ReRoutes属性的操作
            var response = await _repo.Get();
            if (response.IsError) {
                return new BadRequestObjectResult(response.Errors);
            }
            return new OkObjectResult(response.Data.ReRoutes);
        }
        //更新某一个ReRoute
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FileReRoute fileReRoute) {
            try {
                var fileConfiguration= _repo.Get().Result.Data;
                //根据FileReRoute.Key找到要更新的FileReRoute
                //更新FileReRoute

                var response = await _setter.Set(fileConfiguration);

                if (response.IsError) {
                    return new BadRequestObjectResult(response.Errors);
                }

                return new OkObjectResult(fileReRoute);
            }
            catch (Exception e) {
                return new BadRequestObjectResult($"{e.Message}:{e.StackTrace}");
            }
        }
    }
}
