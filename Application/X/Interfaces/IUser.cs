﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.X.Interfaces
{
    public interface IUser
    {
        string UserId { get; }
        string Email { get; }
    }
}
