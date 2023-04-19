using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sample.Core.Domain
{
    public interface IStudentCommandRepository
    {
        void Create(Student entity);
        bool Update(int id, Student entity);
        bool Delete(int id);
    }
}
