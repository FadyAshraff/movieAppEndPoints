using Microsoft.EntityFrameworkCore;
using test.model;

namespace test.context
{
    public class applicationdbcontext:DbContext
    {
        public applicationdbcontext(DbContextOptions<applicationdbcontext>options):base(options)
        {
        }

        public DbSet<genre> genres { get; set; }
        public DbSet<movie> movies { get; set; }
    }   
}
