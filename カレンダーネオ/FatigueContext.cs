using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace カレンダーネオ
{
    class FatigueContext : DbContext
    {
        public DbSet<Ivent> Ivents { get; set; }
    }
}
