﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Core.Command;

namespace CleanArch.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T Command) where T:Command.Command
    }
}