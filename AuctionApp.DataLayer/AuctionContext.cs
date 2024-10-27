using AuctionApp.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.DataLayer
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //User Config
            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id); // Set primary key
                entity.Property(e => e.UserName)
                      .IsRequired()
                      .HasMaxLength(100); // Configure UserName as required with max length
                entity.Property(e => e.UserEmail)
                      .IsRequired()
                      .HasMaxLength(50); // Configure UserEmail as required with max length
                entity.Property(e => e.PasswordHash)
                      .IsRequired();
            });

            //AuctionItem Config
            builder.Entity<AuctionItem>(entity =>
            {
                entity.HasKey(e => e.Id); // Set primary key
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(100); // Configure Title as required with max length
                entity.Property(e => e.Description)
                      .HasMaxLength(500); // Configure Description with max length
                entity.Property(e => e.StartingBid)
                      .IsRequired();
                entity.Property(e => e.EndDate)
                      .IsRequired();
            });

            //AuctionBid Config
            builder.Entity<AuctionBid>(entity =>
            {
                entity.HasKey(e => e.Id); // Set primary key
                entity.Property(e => e.Amount)
                      .IsRequired();  // Configure Amount as required
                entity.HasOne(pf => pf.AuctionItem)
                    .WithMany()
                    .HasForeignKey(pf => pf.AuctionItemId)
                    .IsRequired() // Configure AuctionItemId as required and foriegnkey relation with AuctionItems
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(pf => pf.User)
                    .WithMany()
                    .HasForeignKey(pf => pf.UserId)
                    .IsRequired() // Configure UserId as required and foriegnkey relation with Users
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }


    }

}
