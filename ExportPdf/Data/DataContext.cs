using ExportXls.Models;
using Microsoft.EntityFrameworkCore;

namespace ExportXls.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}
