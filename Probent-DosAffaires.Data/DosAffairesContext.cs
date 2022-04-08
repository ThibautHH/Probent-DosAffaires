/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using Microsoft.EntityFrameworkCore;

namespace ProbentDosAffaires.Data
{
    public partial class DosAffairesContext : DbContext
    {
        public DosAffairesContext(DbContextOptions<DosAffairesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AffaireDosimétrique> AffairesDosimétriques { get; set; } = null!;
        public virtual DbSet<DocumentAffaireDosimétrique> DocumentsAffairesDosimétriques { get; set; } = null!;
        public virtual DbSet<Exposition> Expositions { get; set; } = null!;
        public virtual DbSet<ExpositionImportée> ExpositionsImportées { get; set; } = null!;
        public virtual DbSet<Intervenant> Intervenants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffaireDosimétrique>(entity => entity.Property(e => e.Notes).IsFixedLength());

            modelBuilder.Entity<DocumentAffaireDosimétrique>(entity => entity.HasOne(d => d.AffaireDosimétrique)
                    .WithMany(p => p.DocumentsAffairesDosimétriques)
                    .HasForeignKey(d => d.AffaireDosimétriqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentsAffairesDosimétriques_AffairesDosimétriques"));

            modelBuilder.Entity<Exposition>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.Nom, e.Prénom });

                entity.HasOne(d => d.AffaireDosimétrique)
                    .WithMany(p => p.Expositions)
                    .HasForeignKey(d => d.AffaireDosimétriqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expositions_AffairesDosimétriques");
            });

            modelBuilder.Entity<ExpositionImportée>(entity => entity.HasKey(e => new { e.Intervenant, e.Date }));

            modelBuilder.Entity<Intervenant>(entity => entity.Property(e => e.SalariéId).ValueGeneratedNever());

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
