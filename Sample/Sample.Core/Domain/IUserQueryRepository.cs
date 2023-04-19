using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Domain
{
    public interface IUserQueryRepository
    {
        User Get(string username, string password);
    }
}
