﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Job
{
    public interface IJobLoggerService
    {
        Task LogAsync(string message);
    }
}
