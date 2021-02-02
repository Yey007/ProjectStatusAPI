using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectStatusAPI.Data.DataPoint;
using ProjectStatusAPI.Data.Projects;
using ProjectStatusAPI.Exceptions.Data;

namespace ProjectStatusAPI.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;
        
        public DbSet<DataPointDto> DataPoints { get; set; }
        public DbSet<ProjectDto> Projects { get; set; }

        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        public async Task SaveChangesAsyncWrapper()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new DataAccessException("Something went wrong saving changes!", e);
            }
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_config["ConnectionString"]);
        }
    }
}