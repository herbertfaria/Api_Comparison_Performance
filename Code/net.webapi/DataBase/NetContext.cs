using Microsoft.EntityFrameworkCore;
using Net.Webapi.Database.Entities;
using Net.Webapi.Database.Mapping;

namespace Net.Webapi.Database;

public class NetContext:  DbContext
{

    public NetContext(DbContextOptions options)
           : base(options)
    {
    }
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

        NpgsqlModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PessoalMapping).Assembly);
    }
}
