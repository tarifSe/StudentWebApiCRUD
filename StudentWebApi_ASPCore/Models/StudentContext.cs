using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi_ASPCore.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions options) : base(options) { }
        DbSet<Student> Students { get; set; }
    }
}
