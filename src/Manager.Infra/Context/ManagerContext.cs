using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Manager.Infra.Context;
public class ManagerContext : DbContext
{
    public ManagerContext()
    { }

    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var conection = "server=localhost; port=3306;database=USERMANAGERAPI;uid=root;password=";
        options.UseMySql(conection, ServerVersion.AutoDetect(conection));
    }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }


}
