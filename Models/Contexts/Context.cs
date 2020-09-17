using Microsoft.EntityFrameworkCore;

namespace SenderCoordCore.Models.Contexts {
    public class CoordsContext : DbContext {
        public CoordsContext(){}
        public CoordsContext(DbContextOptions<CoordsContext> options) : base(options) { }

        public virtual DbSet<Coords> Coords { get; set; }
    }
}
