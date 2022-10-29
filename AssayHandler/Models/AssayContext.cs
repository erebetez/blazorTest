using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace AssayHandler.Models
{
    public class AssayContext : DbContext
    {
        public AssayContext(DbContextOptions<AssayContext> options)
            : base(options)
        {
        }

        public DbSet<AssayItem> AssayItem { get; set; } = null!;
    }
}