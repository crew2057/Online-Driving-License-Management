﻿using SahajSewa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Repository.IRepository
{
    public interface ILicenseRepository:IRepository<License>
    {
        void Update(License obj);
    }
}
