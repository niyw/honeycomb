using System;
using System.Collections.Generic;
using System.Text;

namespace Nyw.AppExtensions {
    public class ConsulServiceOptions {
        public string Address { get; set; }
        public int Port { get; set; }
        public string Service { get; set; }
        public string ConsulAddress { get; set; } = "localhost";
        public int ConsulPort { get; set; } = 8500;
    }
}
