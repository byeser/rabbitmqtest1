﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public class Message : IMessage
    {
        public string Text { get; set; }
    }
}
