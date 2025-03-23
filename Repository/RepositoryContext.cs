using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base (options){}
    
    public DbSet<Faculty>? Faculties { get; init; }
    public DbSet<Student>? Students { get; init; }
    public DbSet<Group> Groups { get; init; }
}