using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nyw.VendorService.Models;

namespace Nyw.VendorService.Controllers {
    [Route("api/[controller]")]
    public class ValuesController : Controller {
        private static List<VendorModel> vendors = new List<VendorModel> {
            new VendorModel{ Id=1 },
            new VendorModel{ Id=2, Name="京东" },
            new VendorModel{ Id=3, Name="腾讯"}
        };
        public ValuesController() { }
        // GET api/values
        [HttpGet]
        public IEnumerable<VendorModel> Get() {
            return vendors;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public VendorModel Get(int id) {
            return vendors.Where(v => v.Id == id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id) {
            return $"delete vendor:{id} success";
        }
    }
}
