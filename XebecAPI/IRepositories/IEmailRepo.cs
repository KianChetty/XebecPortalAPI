﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.IRepositories
{
    public interface IEmailRepo
    {
        Task<bool> ConfrimRegisterKey(AppUser user);


    }
}