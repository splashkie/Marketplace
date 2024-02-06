using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp7.Models
{
    public class DbHelper : DbContext
    {
        public DbSet<User> users { get; set; } = null!;
        public string connstring = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=fhntv123";
        public DbHelper()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connstring);
        }
        async public Task<User> GetUser(string name, CancellationToken cancellationToken = default)
        {
            return await users.FirstOrDefaultAsync<User>(x => x.Name == name, cancellationToken) ?? new User();
        }
        async public Task<User> GetUser(int id, CancellationToken cancellationToken=default)
        {
            return await users.FirstOrDefaultAsync<User>(x=>x.Id==id,cancellationToken)?? new User();
        }
    }
}
