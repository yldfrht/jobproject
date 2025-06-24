using App.DataAccess;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Job
{
    public class JobLoggerService(AppDbContext context) : IJobLoggerService
    {
        public async Task LogAsync(string message)
        {
            var log = new JobLog { Message = message };
            await context.JobLogs.AddAsync(log);
            await context.SaveChangesAsync();
        }
    }
}
