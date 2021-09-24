using EmreCrm.Model.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace EmreCrm.Data.Context
{
    public class EmreCrmContext : DbContext
    {
        public EmreCrmContext(DbContextOptions<EmreCrmContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
