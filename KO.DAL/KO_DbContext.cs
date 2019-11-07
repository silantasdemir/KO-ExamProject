using KO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KO.DAL
{
    public class KO_DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.; Database=KO_DB; uid=sa; pwd=123;");

            optionsBuilder.UseSqlite(@"Data Source=KO.db;");

            //optionsBuilder.UseSqlite("Filename=KO.db", options =>
            //{ options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); });
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(new Member { ID = 1, Username = "silan", Password = "123" });
        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<MemberExam> MemberExams { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
    }
}
