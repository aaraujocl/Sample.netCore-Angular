using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.Domain
{
    public class StudentQueryRepository : IStudentQueryRepository
    {

        private readonly ContextDB _context;

        public StudentQueryRepository(ContextDB context)
        {
            _context = context;
        }

        public Student Get(int id)
        {
            try
            {
                return _context.Student.AsQueryable().Where(student => student.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Student> GetList()
        {
            try
            {
                return _context.Student.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
