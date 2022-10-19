using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exam_Api.Models
{
    public partial class ExamContext : DbContext
    {
        public ExamContext()
        {
        }

        public ExamContext(DbContextOptions<ExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<ExamTitle> ExamTitles { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = DESKTOP-1ILHJLP; Database = Exam; Trusted_Connection = true ;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Answer1).HasColumnName("Answer");
            });

            modelBuilder.Entity<ExamTitle>(entity =>
            {
                entity.ToTable("ExamTitle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasMany(d => d.Questions)
                    .WithMany(p => p.Exams)
                    .UsingEntity<Dictionary<string, object>>(
                        "ExamQuestion",
                        l => l.HasOne<Question>().WithMany().HasForeignKey("QuestionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ExamQuestions_Questions"),
                        r => r.HasOne<ExamTitle>().WithMany().HasForeignKey("ExamId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ExamQuestions_ExamTitle"),
                        j =>
                        {
                            j.HasKey("ExamId", "QuestionId");

                            j.ToTable("ExamQuestions");

                            j.IndexerProperty<int>("ExamId").HasColumnName("Exam_ID");

                            j.IndexerProperty<int>("QuestionId").HasColumnName("Question_ID");
                        });
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.AnswerId).HasColumnName("Answer_Id");

                entity.Property(e => e.Question1).HasColumnName("Question");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Answers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
