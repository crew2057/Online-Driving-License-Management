using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Repository
{
    public class Module : IModule
    {
        private readonly ApplicationDbContext _db;
        public Module(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
