using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_EFCore2.Models
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options):base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
