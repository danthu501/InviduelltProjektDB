using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InviduelltProjektDB.Models
{
    public partial class IndividuelltDatabasprojektContext : DbContext
    {
        public IndividuelltDatabasprojektContext()
        {
        }

        public IndividuelltDatabasprojektContext(DbContextOptions<IndividuelltDatabasprojektContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anställda> Anställda { get; set; }
        public virtual DbSet<Avdelning> Avdelning { get; set; }
        public virtual DbSet<Betyg> Betyg { get; set; }
        public virtual DbSet<Elev> Elev { get; set; }
        public virtual DbSet<ElevBetyg> ElevBetyg { get; set; }
        public virtual DbSet<Klass> Klass { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-6TSF82P; Initial Catalog = IndividuelltDatabasprojekt; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anställda>(entity =>
            {
                entity.HasKey(e => e.AnställningsNummer);

                entity.Property(e => e.AnställningsDatum).HasColumnType("date");

                entity.Property(e => e.Befattning).HasMaxLength(50);

                entity.Property(e => e.EfterNamn).HasMaxLength(50);

                entity.Property(e => e.FavdelningsId).HasColumnName("FAvdelningsId");

                entity.Property(e => e.FörNamn).HasMaxLength(50);

                entity.Property(e => e.Lön).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Favdelnings)
                    .WithMany(p => p.Anställda)
                    .HasForeignKey(d => d.FavdelningsId)
                    .HasConstraintName("FK_Anställda_Avdelning");
            });

            modelBuilder.Entity<Avdelning>(entity =>
            {
                entity.HasKey(e => e.AvdelningsId);

                entity.Property(e => e.AvdelningsId).ValueGeneratedNever();

                entity.Property(e => e.AvdelningsNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.Property(e => e.Betyg1).HasColumnName("Betyg");

                entity.Property(e => e.BetygetSatDatum).HasColumnType("date");

                entity.Property(e => e.BetygsättandeLärareId).HasColumnName("BetygsättandeLärareID");

                entity.HasOne(d => d.BetygsättandeLärare)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.BetygsättandeLärareId)
                    .HasConstraintName("FK_Betyg_Anställda");

                entity.HasOne(d => d.KursNavigation)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.Kurs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Ämne");
            });

            modelBuilder.Entity<Elev>(entity =>
            {
                entity.Property(e => e.EfterNamn).HasMaxLength(50);

                entity.Property(e => e.FörNamn).HasMaxLength(50);

                entity.Property(e => e.Personnummer).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.KlassNavigation)
                    .WithMany(p => p.Elev)
                    .HasForeignKey(d => d.Klass)
                    .HasConstraintName("FK_Elev_Klass");
            });

            modelBuilder.Entity<ElevBetyg>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Betyg)
                    .WithMany()
                    .HasForeignKey(d => d.BetygId)
                    .HasConstraintName("FK_ElevBetyg_Betyg");

                entity.HasOne(d => d.Elev)
                    .WithMany()
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK_ElevBetyg_Elev");
            });

            modelBuilder.Entity<Klass>(entity =>
            {
                entity.Property(e => e.KlassId).ValueGeneratedNever();

                entity.Property(e => e.KlassNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.Property(e => e.KursId).ValueGeneratedNever();

                entity.Property(e => e.KursNamn).HasMaxLength(50);

                entity.Property(e => e.KursSlutDatum).HasColumnType("date");

                entity.Property(e => e.KursStart).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
