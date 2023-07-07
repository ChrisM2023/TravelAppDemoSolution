using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAppDataAccess.Model;

namespace TravelAppDataAccess.Context
{
    public class TravelAppDemoContext : DbContext
    {
        public TravelAppDemoContext(DbContextOptions options) : base(options)
        {
        }

        protected TravelAppDemoContext()
        {
        }
        public DbSet<TravelAppDemoModel> TravelAppDemoModel {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelAppDemoModel>(
                entity =>
                {
                    
                    entity.ToTable("TravelAppDemoTable");
                    entity.HasKey(e => e.TravelId);
                    entity.Property(e => e.TravelId);

                    entity.Property(e => e.Activity);
                    entity.Property(e => e.HasDone);
                    entity.Property(e => e.Mandatory);
                    entity.Property(e => e.Description);
                    entity.Property(e => e.Companion);
                    entity.Property(e => e.Notes);
                    entity.Property(e => e.Destination);
                    entity.Property(e => e.Appointment);

                   

                }
                
                );

        }
    }
}
