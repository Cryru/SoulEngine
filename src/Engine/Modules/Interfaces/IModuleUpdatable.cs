﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulEngine.Modules
{
    interface IModuleUpdatable : IModule
    {
        void Update();
    }
}
