using System.Data.Entity;
using UrlShortner.Models;

namespace UrlShortner.DAL
{
    public class UrlContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }
        public DbSet<UrlStat> UrlStats { get; set; }
    }
}