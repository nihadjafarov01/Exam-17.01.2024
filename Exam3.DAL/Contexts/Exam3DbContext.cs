namespace Exam3.DAL.Contexts
{
    public class Exam3DbContext : IdentityDbContext
    {
        public Exam3DbContext(DbContextOptions options) : base(options) { }
        public DbSet<Card> Cards { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .Property(b => b.CreatedTime)
                    .HasDefaultValue(DateTime.Now);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Card).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
