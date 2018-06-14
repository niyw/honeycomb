using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyw.EmployeeServices.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Mail { get; set; }
        public string NameCN { get; set; }
        public string NameEN { get; set; }
    }
}
