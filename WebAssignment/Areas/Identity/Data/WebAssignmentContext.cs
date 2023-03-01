using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebAssignment.Areas.Identity.Data;
using WebAssignment.Models;

namespace WebAssignment.Data;

public class WebAssignmentContext : IdentityDbContext<WebAssignmentUser>
{
    public WebAssignmentContext(DbContextOptions<WebAssignmentContext> options)
        : base(options)
    {
    }
    public DbSet<Item> Items { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Item>().HasData(
               new Item
               {
                   ItemId = 1,
                   ItemName = "PlayStation 5",
                   ItemDescription = "Sony next-gen gaming console",
                   MinBid = 1000,
                   AuctionStart = DateTime.Now,
                   AuctionEnd = new DateTime(2023, 03, 23),
                   ItemCondition = "New",
                   Category = "Electronics",
                   ImageUrl = "https://i5.walmartimages.com/asr/fd596ed4-bf03-4ecb-a3b0-7a9c0067df83.bb8f535c7677cebdd4010741c6476d3a.png?odnHeight=612&odnWidth=612&odnBg=FFFFFF"
               },
               new Item
               {
                   ItemId = 2,
                   ItemName = "Jordan 1 Lost and Found",
                   ItemDescription = "2022 Sneaker of the Year",
                   MinBid = 5000,
                   AuctionStart = DateTime.Now,
                   AuctionEnd = new DateTime(2023, 03, 23),
                   ItemCondition = "Used",
                   Category = "Shoes",
                   ImageUrl = "https://solesavy.com/wp-content/uploads/2022/08/Air-Jordan-1-Lost-and-Found-DZ5485-612-Release-Date.jpeg"
               }
           );
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
