using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity.Models
{
    public partial class QuizDBContext : DbContext
    {
        public QuizDBContext()
        {
        }

        public QuizDBContext(DbContextOptions<QuizDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=QuizDB;Trusted_Connection=True;User ID=sa;Password=Iloveyou1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.ParticipantId);
                entity.Property(e => e.Score);
                entity.Property(e => e.TimeTaken);
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QnId);

                entity.Property(e => e.ImageName).HasMaxLength(50);

                entity.Property(e => e.Option1).HasMaxLength(50);

                entity.Property(e => e.Option2).HasMaxLength(50);

                entity.Property(e => e.Option3).HasMaxLength(50);

                entity.Property(e => e.Option4).HasMaxLength(50);

                entity.Property(e => e.QnInWords).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
