using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnfermariaSenac.Models;

namespace EnfermariaSenac.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        public DbSet<EnfermariaSenac.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<EnfermariaSenac.Models.Enfermagem> Enfermagem { get; set; } = default!;
        public DbSet<EnfermariaSenac.Models.Prontuario> Prontuario { get; set; } = default!;
        public DbSet<EnfermariaSenac.Models.Usuario> Usuario { get; set; } = default!;
        





    }
}
