namespace FormulaOneApp.Data;
using Microsoft.EntityFrameworkCore;
using FormulaOneApp.Models;

public class ApiDbContext  : DbContext
{
    public DbSet<Team> Teams { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }





}