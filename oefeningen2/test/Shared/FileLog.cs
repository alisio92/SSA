using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FileLog
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string UserName { get; set; }
        public string Creator { get; set; }
        public DateTime DateTime { get; set; }
    }
}
