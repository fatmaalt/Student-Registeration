using Microsoft.EntityFrameworkCore;

namespace student_registration.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Studentt> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                                .Property(user => user.Role).HasDefaultValue("Student");
        }
  
    }
}