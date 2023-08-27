using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        {

        }

        public MovieContext(DbContextOptions<MovieContext> opt):base(opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }

        // Dinh nghia them
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5169M4OF\\SQLEXPRESS;Initial Catalog=DbbbTest;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(p =>
            {
                p.ToTable("Movie");
                p.HasKey( mv => mv.Id );
                p.HasOne(x => x.Genres).WithMany(y => y.Movies).HasForeignKey(z => z.GenreId).HasConstraintName("FK_Movie_Genre");
              
              

            });

            modelBuilder.Entity<Genre>(p =>
            {
                p.ToTable("Genre");
                p.HasKey(gr => gr.Id);
               

            });


            modelBuilder.Entity<Actor>(p =>
            {
                p.ToTable("Actor");
                p.HasKey(at => at.Id);
                p.HasOne(x => x.Movies).WithMany(y => y.Actors).HasForeignKey(z => z.MovieId).HasConstraintName("FK_Actor_Movie");

            });
        }
    }
}
