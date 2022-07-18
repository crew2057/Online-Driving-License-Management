using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Repository.IRepository
{
    public interface IModule
    {
        ILicenseRegistrationRepository LicenseRegistration { get; }
        ILicenseRepository License { get; }
        void Save();
    }
}
