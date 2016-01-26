﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Interfaces.Handlers
{
    public interface IEventHandler
    {
        void Handle(IEvent evt);
    }
}
