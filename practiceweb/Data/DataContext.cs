namespace practiceweb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> koyal): base(koyal)  { }
        public DbSet<Vampires > Vampires { get; set; }
        ////public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        ////public DbSet<Vampires> Vampires { get; set; }   
        ////be warrior
    }
}


