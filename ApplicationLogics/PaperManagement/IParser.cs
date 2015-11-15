﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement
{
    public interface IParser
    {
        IList<string> Parse(string data);
    }
}
