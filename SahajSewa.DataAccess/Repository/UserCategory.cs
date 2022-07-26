using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Repository
{
    public class UserCategoryRepository : Repository<UserCategory>, IUserCategoryRepository
    {
        private ApplicationDbContext _db;
        public UserCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserCategory obj)
        {
            var objFromDb = _db.UserCategories.FirstOrDefault(u => u.UserId == obj.UserId);
            if (objFromDb != null)
            {
                objFromDb.UserId = obj.UserId;
                objFromDb.CategoryId = obj.CategoryId;
            }

        }
    }
}
