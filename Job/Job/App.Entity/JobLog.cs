using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity
{
    public class JobLog
    {
        public int Id { get; set; }
        public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
        public string Message { get; set; } = string.Empty;
    }
}
