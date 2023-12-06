﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}