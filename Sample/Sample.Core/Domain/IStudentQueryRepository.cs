using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sample.Core.Domain
{
    public interface IStudentQueryRepository
    {
        IEnumerable<Student> GetList();

        Student Get(int id);
    }
}
