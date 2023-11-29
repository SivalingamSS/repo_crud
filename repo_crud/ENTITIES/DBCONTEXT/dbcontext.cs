using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES.MODEL;
using DOT.VIEW_MODEL;

namespace ENTITIES.DBCONTEXT
{
    public  class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions options) : base(options) { }
        public DbSet<regiter> TBM_regiter { get; set; }
        public DbSet<Regiter_STUD> TBM_Regiter_STUD { get; set; }
       


    }
}
