using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Models;
using Microsoft.EntityFrameworkCore;


namespace CC.Models
{
    public class GroupDataContext:DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        
       public GroupDataContext(DbContextOptions<GroupDataContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
