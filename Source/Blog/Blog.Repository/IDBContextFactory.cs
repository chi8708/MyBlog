﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    internal interface IDBContextFactory
    {
        DbContext GetCurrentContextInstence();
    }
}
