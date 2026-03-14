using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week10Asessment.Models;

namespace Week10Asessment.Data
{
    public class Week10AsessmentContext : DbContext
    {
        public Week10AsessmentContext (DbContextOptions<Week10AsessmentContext> options)
            : base(options)
        {
        }

        public DbSet<Week10Asessment.Models.Transaction> Transaction { get; set; } = default!;
        public DbSet<Week10Asessment.Models.Assets> Assets { get; set; } = default!;
    }
}
