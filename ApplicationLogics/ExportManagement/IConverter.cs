﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.ExportManagement
{
    public interface IConverter
    {
        IExportFile Convert(Protocol protocol);
    }
}
