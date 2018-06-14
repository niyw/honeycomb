using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nyw.EmployeeServices.Models;

namespace Nyw.EmployeeServices.Controllers {
    [Route("api/[controller]")]
    public class ValuesController : Controller {
        private static List<EmployeeModel> employees = new List<EmployeeModel> {
            new EmployeeModel{Id=1, Alias="zhangsan", NameCN="张三", NameEN="san zhang", Mail="zhangsan@nyw.com" },
            new EmployeeModel{Id=2, Alias="lisi", NameCN="李四", NameEN="si li", Mail="lisi@nyw.com" },
            new EmployeeModel{Id=3, Alias="wangwu", NameCN="王五", NameEN="wu wang", Mail="wangwu@nyw.com" },
            new EmployeeModel{Id=4, Alias="zhaoliu", NameCN="赵六", NameEN="liu zhao", Mail="zhaoliu@nyw.com" }
        };
        // GET api/values
        [HttpGet]
        public IEnumerable<EmployeeModel> Get() {
            return employees;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public EmployeeModel Get(int id) {
            return employees.Where(e => e.Id == id).FirstOrDefault();
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
            return $"delete employee:{id} success";
        }
    }
}
