﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailConfirmationAsync(string email, object callbackUrl)
        {
            throw new NotImplementedException();
        }
    }
}
