﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Auth
{
    public class SendEmailDTO
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
