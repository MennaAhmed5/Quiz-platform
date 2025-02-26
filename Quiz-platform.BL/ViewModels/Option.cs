﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.ViewModels
{
    public class Option
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public Option(string name, string value)
        { 
            Name = name;
            Value = value;
        }
    }
}
