using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyw.VendorService.Models {
    public class VendorModel {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Microsoft";
        public string Address { get; set; } = "上海市虹桥路3号";
        public string Country { get; set; } = "CN";
    }
}
