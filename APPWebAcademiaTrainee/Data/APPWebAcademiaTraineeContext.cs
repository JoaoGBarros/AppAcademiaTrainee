using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APPWebAcademiaTrainee.Models;

namespace APPWebAcademiaTrainee.Data
{
    public class APPWebAcademiaTraineeContext : DbContext
    {
        public APPWebAcademiaTraineeContext (DbContextOptions<APPWebAcademiaTraineeContext> options)
            : base(options)
        {
        }

        public DbSet<APPWebAcademiaTrainee.Models.PessoaModel> PessoaModel { get; set; }
    }
}
