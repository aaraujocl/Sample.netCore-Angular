using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.Domain
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly ContextDB _context;

        public UserQueryRepository(ContextDB context)
        {
            _context = context;
        }
        public User Get(string username, string password)
        {
            try
            {
                return _context.User.AsQueryable().Where(student => student.UserName == username && student.Password == password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
