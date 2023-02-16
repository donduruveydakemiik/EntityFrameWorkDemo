using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDemo
{
    public class ETradeContext:DbContext //
    {
        public DbSet<Product> Products { get; set; } // product nesnesinde Products adında table arar veri tabanında .

    }
}
