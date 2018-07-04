using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;


namespace Nyw.Portal.Controllers {
    public class RedisController : Controller {
        public IActionResult Index() {
            var cfg = ConfigurationOptions.Parse("localhost:6379");
            //cfg.Password = "P2ssw0rd";
           
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(cfg);
            IDatabase db = redis.GetDatabase();

            string cVal = "abcdefg";
            var cKey = "mykey";
            db.StringSet(cKey, cVal);
            System.Diagnostics.Trace.WriteLine($"Set {nameof(cKey)}'s value : {cVal} to Redis");

            cVal = db.StringGet(cKey);
            System.Diagnostics.Trace.WriteLine($"Get {nameof(cKey)}'s value : {cVal} from Redis");
            return View();
        }
    }
}