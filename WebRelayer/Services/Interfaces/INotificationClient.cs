﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Services
{
    public interface INotificationClient
    {
        Task Send(string json);
    }
}
