using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Phase3Project3.Models
{
    public partial class SchoolDb2Context : DbContext
    {
        public SchoolDb2Context()
        {
        }

        public SchoolDb2Context(DbContextOptions<SchoolDb2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Student1> Student1s { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-L12EV7F;database=SchoolDb2;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).ValueGeneratedNever();

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student1>(entity =>
            {
                entity.HasKey(e => e.StudentRollNo)
                    .HasName("PK__Student1__7A3511C80F85A1F1");

                entity.ToTable("Student1");

                entity.Property(e => e.StudentRollNo).ValueGeneratedNever();

                entity.Property(e => e.StudentName).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Student1s)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Student1__ClassI__5165187F");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Student1s)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Student1__Subjec__52593CB8");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName).HasMaxLength(50);

                entity.Property(e => e.TeacherName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
