﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoPixelServer.ViewModels
{
    public abstract class BaseViewModel
    {
        public List<EditablePropertyViewModel> Properties { get; set; }
    }
}
