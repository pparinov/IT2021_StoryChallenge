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
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ChallengeSubscription> ChallengeSubscriptions { get; set; }
        public DbSet<ChallengeUser> ChallengeUsers { get; set; }
        public DbSet<ChapterChallenge> ChallengeChapters { get; set; }
        public DbSet<ChapterUser> ChapterUsers { get; set; }
        public DbSet<PictureChallenge> ChallengePictures { get; set; }
        public DbSet<PictureChapter> ChapterPictures { get; set; }
        public DbSet<PictureUser> UserPictures { get; set; }
        public DbSet<TagChallenge> ChallengeTags { get; set; }
        public DbSet<TagSubscription> TagSubscriptions { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubscription>()
                .HasAlternateKey(e => new { e.SubscriberId, e.SubscribedOnId });
            modelBuilder.Entity<ChallengeSubscription>()
                .HasAlternateKey(e => new { e.UserId, e.ChallengeId });
            modelBuilder.Entity<ChallengeUser>()
                .HasAlternateKey(e => new { e.UserId, e.ChallengeId, e.StatusId });
            modelBuilder.Entity<ChapterUser>()
                .HasAlternateKey(e => new { e.ChapterId, e.UserId });
            modelBuilder.Entity<PictureChallenge>()
                .HasAlternateKey(e => new { e.ChallengeId, e.PictureId });
            modelBuilder.Entity<PictureChapter>()
                .HasAlternateKey(e => new { e.ChapterId, e.PictureId });
            modelBuilder.Entity<PictureUser>()
                .HasAlternateKey(e => new { e.UserId, e.PictureId });
            modelBuilder.Entity<TagChallenge>()
                .HasAlternateKey(e => new { e.ChallengeId, e.TagId });
            modelBuilder.Entity<TagSubscription>()
                .HasAlternateKey(e => new { e.UserId, e.TagId });
            modelBuilder.Entity<Status>()
                .HasAlternateKey(p => new { p.State });
            modelBuilder.Entity<User>()
                .HasAlternateKey(p => new { p.UserName });
            modelBuilder.Entity<Tag>()
                .HasAlternateKey(p => new { p.Name });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Горе от ума", StartDate = DateTime.Now, EndDate = new DateTime(2021 , 12 , 31) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "1984", StartDate = new DateTime(2021 , 03 , 05), EndDate = DateTime.Now });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Государь", StartDate = new DateTime(2020 , 06 , 01), EndDate = new DateTime(2022 , 06 , 01) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Одиннадцать минут", StartDate = new DateTime(2020 , 02 , 20), EndDate = new DateTime(2020 , 09 , 30) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Человек для себя", StartDate = new DateTime(2021 , 10 , 13), EndDate = DateTime.Now });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Секрет шведского благополучия", StartDate = new DateTime(2020 , 05 , 04), EndDate = new DateTime(2021 , 10 , 13) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Цивилизация с нуля", StartDate = new DateTime(2020 , 05 , 24), EndDate = new DateTime(2021 , 05 , 11) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Лисья нора", StartDate = new DateTime(2021 , 09 , 21), EndDate = new DateTime(2021 , 10 , 6) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Повелитель мух", StartDate = new DateTime(2020 , 02 , 20), EndDate = new DateTime(2021 , 02 , 09) });
            modelBuilder.Entity<Challenge>().HasData(new Challenge() { Id = Guid.NewGuid(), Name = "Капитал", StartDate = new DateTime(2020 , 02 , 27), EndDate = new DateTime(2021 , 10 , 29) });

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
