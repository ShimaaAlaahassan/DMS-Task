using DMS_Task.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DMS_Task.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext()
		{

		}
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		
		//to add composite key and fk
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<UserSchedule>().HasKey("UserId", "ScheduleId");
			//modelBuilder.Entity<PatientAppointment>().HasKey("ScheduleId", "PatientId");
			
		}
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Secratery> Secrateries { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<PatientAppointment> PatientsAppointment { get; set; }
		
		
	}
}

