using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace MyApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<Salutation> Salutation { get; set; }
        public DbSet<FileDownloadDetails> FileDownloadDetails { get; set; }
    }
}