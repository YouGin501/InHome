using Microsoft.EntityFrameworkCore;
using web_site_Domain.Models;

namespace web_site_DAL.Data
{
    public class WebSiteDbContext : DbContext
    {
        public WebSiteDbContext(DbContextOptions<WebSiteDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Rent> Rents { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Design> Designs { get; set; }
        public DbSet<ResidentialComplex> ResidentialComplexes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ImageUrl> ImageUrls { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.SubscriberSubscriptions)
                .WithOne(s => s.Subscriber)
                .HasForeignKey(s => s.SubscriberId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.ReceiverSubscriptions)
                .WithOne(s => s.Receiver)
                .HasForeignKey(s => s.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.UserLikes)
                .WithOne(l => l.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Feedbacks)
                .WithOne(r => r.WrittenForUser)
                .HasForeignKey(x => x.WrittenForUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // +
            modelBuilder
                .Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder
                .Entity<Post>()
                .HasMany(p => p.Photos)
                .WithOne(c => c.Post)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder
                .Entity<Post>()
                .HasMany(p => p.PostLikes)
                .WithOne(c => c.Post)
                .OnDelete(DeleteBehavior.Cascade);
            //
            modelBuilder
                .Entity<Project>()
                .HasMany(p => p.Likes)
                .WithOne(l => l.Project)
                .OnDelete(DeleteBehavior.Cascade);
            // +
            modelBuilder
                .Entity<Location>()
                .HasMany(r => r.Projects)
                .WithOne(p => p.Location)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder
                .Entity<Location>()
                .HasMany(l => l.Posts)
                .WithOne(p => p.Location)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder
                .Entity<Location>()
                .HasMany(l => l.ResidentialComplexes)
                .WithOne(p => p.Location)
                .OnDelete(DeleteBehavior.SetNull);

            // +
            modelBuilder
                .Entity<ImageUrl>()
                .HasOne(r => r.Project)
                .WithMany(i => i.PhotosUrls)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<ImageUrl>()
                .HasOne(r => r.Post)
                .WithMany(i => i.Photos)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<ImageUrl>()
                .HasOne(r => r.ResidentialComplex)
                .WithMany(i => i.PhotoUrls)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Like>()
                .HasOne(l => l.Project)
                .WithMany(l => l.Likes)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<ResidentialComplex>()
                .HasMany(p => p.PhotoUrls)
                .WithOne(c => c.ResidentialComplex)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
