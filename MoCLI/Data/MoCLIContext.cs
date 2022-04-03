using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoCLI.Data.Models;

namespace MoCLI.Data
{
    public class MoCLIContext : DbContext
    {
        public string Connection { get; set; } = null!;

        public DbSet<Card> Cards => Set<Card>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(Connection ?? "Data Source=HP-ENVY; Initial Catalog=MoCLI; Integrated Security=True");
    }
}
