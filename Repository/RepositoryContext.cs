using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Faculty>? Faculties { get; init; }
    public DbSet<Student>? Students { get; init; }
    public DbSet<Group> Groups { get; init; }
}