using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class webContext : DbContext
{
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleTag> ArticleTags { get; set; }

    private string connectionstring = @"
            Data Source=localhost,1433;
            Initial Catalog = webdb;
            User ID = sa;
            Password= CASter789";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(connectionstring);
        optionsBuilder.UseLoggerFactory(loggerFactory);
        Console.WriteLine("On configuring");
    }
    public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning);
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        builder.AddConsole();
    });
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Console.WriteLine("OnModelCreating");
        modelBuilder.Entity<ArticleTag>(entity =>
        {
            entity.HasIndex(aaa => new { aaa.ArticleTagId, aaa.TagId })
                   .IsUnique();
        });
    }
}
