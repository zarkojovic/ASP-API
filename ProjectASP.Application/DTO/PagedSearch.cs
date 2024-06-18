﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO
{
    public class PagedSearch
    {
        public int? PerPage { get; set; } = 10;
        public int? Page { get; set; } = 1;
    }
}
