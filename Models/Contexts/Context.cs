using Microsoft.EntityFrameworkCore;

namespace SenderCoordCore.Models.Contexts {
    public partial class CoordsContext : DbContext {

        public CoordsContext() { }

        public CoordsContext(DbContextOptions<CoordsContext> option) : base(option) { }

        private readonly CoordsContext _context;
        public CoordsContext(CoordsContext context) {
            _context = context;
        }


        public virtual DbSet<Coords> Coords { get; set; }
    }
}
