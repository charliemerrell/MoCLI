﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCLI.Data.DTOs
{
    public class CardCreateDTO
    {
        public string Prompt { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}
