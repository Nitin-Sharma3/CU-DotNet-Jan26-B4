using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day62_01.Models;

namespace Day62_01.Data
{
    public class Day62_01Context : DbContext
    {
        public Day62_01Context (DbContextOptions<Day62_01Context> options)
            : base(options)
        {
        }

        public DbSet<Day62_01.Models.Loan> Loan { get; set; } = default!;
    }
}
