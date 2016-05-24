using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webshop.Models
{
    public class ProgrammingFramework
    {
        public int ProgrammingFrameworkId { get; set; }
        public string Name { get; set; }
        public List<Device> Devices { get; set; }

    }
}
