﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkCS10._06._24.Exceptions
{
    public class EmailAlreadyExists : Exception
    {
        public EmailAlreadyExists(string message)
        : base(message)
        {
        }
    }
}