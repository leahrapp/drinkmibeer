using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DrinkMiBeer.Core.Entities;



namespace DrinkMiBeer.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {


        public RepositoryContext(DbContextOptions options) : base(options)
        {
          
        }
      
        public DbSet<Brewery> Brewery { get; set; }
    }
}
