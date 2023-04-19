using Microsoft.EntityFrameworkCore;
using Sample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository
{
    public class ContextDB: DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options): base(options) { }

        public DbSet<Student> Student { get; set; }

        public DbSet<User> User { get; set; }
    }
}
