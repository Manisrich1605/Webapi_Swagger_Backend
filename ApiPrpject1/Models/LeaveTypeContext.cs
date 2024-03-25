using ApiPrpject1.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiPrpject1.Models
{
    public class LeaveTypeContext : DbContext
    {
        public LeaveTypeContext(DbContextOptions<LeaveTypeContext> options) : base(options)
        {
        }
        public DbSet<LeaveType> LeaveTypess { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reactportfolio> Reactportfolios { get; set; }
        public DbSet<Javascriptportfolio> Javascriptportfolios { get; set; }

        public DbSet<Jsregister> Jsregisters { get; set; }

    }

}