using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class ChallengesContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<UserSubscription> UsersSubscriptions { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ChallengeSubscription> ChallengesSubscriptions { get; set; }
        public DbSet<ChallengeUser> ChallengesUsers { get; set; }
        public DbSet<ChapterChallenge> ChaptersChallenges { get; set; }
        public DbSet<ChapterUser> ChaptersUsers { get; set; }
        public DbSet<CommentChapter> CommentsChapters { get; set; }
        public DbSet<CommentUser> CommentsUsers { get; set; }
        public DbSet<PictureChallenge> PicturesChallenges { get; set; }
        public DbSet<PictureChapter> PicturesChapters { get; set; }
        public DbSet<PictureUser> PicturesUsers { get; set; }
        public DbSet<TagChallenge> TagsChallenges { get; set; }
        public DbSet<TagSubscription> TagsSubscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubscription>()
                .HasIndex(p => new { p.SubscriberId, p.SubscribedOnId })
                .IsUnique(true);
        }

        public ChallengesContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StoryChallenges;Trusted_Connection=True;");
        }
    }
}
