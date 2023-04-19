using Microsoft.EntityFrameworkCore;
using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sample.Repository.Domain
{
    public class StudentCommandRepository : IStudentCommandRepository
    {

        private readonly ContextDB _context;

        public StudentCommandRepository(ContextDB context)
        {
            _context = context;
        }
        public void Create(Student entity)
        {
            try
            {
                _context.Student.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                var entity = _context.Student.Where(d => d.Id == id).First();
                if (entity == null)
                {
                    return false;
                }
                else
                {
                    _context.Student.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool Update(int id, Student entity)
        {
            try
            {
                var update = _context.Student.FirstOrDefault(estudent => estudent.Id == id);
                // Validate entity is not null
                if (update == null)
                {
                    return false;
                }
                else
                {
                  
                    // Make changes on entity
                    update.UserName = entity.UserName;
                    update.FirstName = entity.FirstName;
                    update.LastName = entity.LastName;
                    update.Career = entity.Career;
                    update.Age = entity.Age;

                    // context.Products.Update(entity);

                    // Save changes in database
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return true;
        }
    }
}
