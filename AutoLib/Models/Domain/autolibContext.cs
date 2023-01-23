using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutoLib.Models.Domain
{
    public partial class autolibContext : DbContext
    {
        public autolibContext()
        {
        }

        public autolibContext(DbContextOptions<autolibContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Borne> Borne { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<TypeVehicule> TypeVehicule { get; set; }
        public virtual DbSet<Utilise> Utilise { get; set; }
        public virtual DbSet<Vehicule> Vehicule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=userepul;password=epul;database=autolib", x => x.ServerVersion("10.4.25-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borne>(entity =>
            {
                entity.HasKey(e => e.IdBorne)   
                    .HasName("PRIMARY");

                entity.ToTable("borne");

                entity.HasIndex(e => e.IdVehicule)
                    .HasName("fk_Borne_Vehicule1_idx");

                entity.HasIndex(e => e.Station)
                    .HasName("fk_Borne_Station1_idx");

                entity.Property(e => e.IdBorne)
                    .HasColumnName("idBorne")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EtatBorne).HasColumnName("etatBorne");

                entity.Property(e => e.IdVehicule)
                    .HasColumnName("idVehicule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Station)
                    .HasColumnName("station")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdVehiculeNavigation)
                    .WithMany(p => p.Borne)
                    .HasForeignKey(d => d.IdVehicule)
                    .HasConstraintName("fk_Borne_Vehicule1");

                entity.HasOne(d => d.StationNavigation)
                    .WithMany(p => p.Borne)
                    .HasForeignKey(d => d.Station)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Borne_Station1");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("client");

                entity.Property(e => e.IdClient)
                    .HasColumnName("idClient")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateNaissance)
                    .HasColumnName("date_naissance")
                    .HasColumnType("date");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => new { e.Vehicule, e.Client, e.DateReservation })
                    .HasName("PRIMARY");

                entity.ToTable("reservation");

                entity.HasIndex(e => e.Client)
                    .HasName("fk_Reservation_Client1_idx");

                entity.HasIndex(e => e.Vehicule)
                    .HasName("fk_Reservation_Vehicule1_idx");

                entity.Property(e => e.Vehicule)
                    .HasColumnName("vehicule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Client)
                    .HasColumnName("client")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateReservation)
                    .HasColumnName("date_reservation")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEcheance)
                    .HasColumnName("date_echeance")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reservation_Client1");

                entity.HasOne(d => d.VehiculeNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.Vehicule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reservation_Vehicule1");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.IdStation)
                    .HasName("PRIMARY");

                entity.ToTable("station");

                entity.Property(e => e.IdStation)
                    .HasColumnName("idStation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adresse)
                    .HasColumnName("adresse")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CodePostal)
                    .HasColumnName("code_postal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ville)
                    .HasColumnName("ville")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TypeVehicule>(entity =>
            {
                entity.HasKey(e => e.IdTypeVehicule)
                    .HasName("PRIMARY");

                entity.ToTable("type_vehicule");

                entity.Property(e => e.IdTypeVehicule)
                    .HasColumnName("idType_vehicule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categorie)
                    .IsRequired()
                    .HasColumnName("categorie")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeVehicule1)
                    .IsRequired()
                    .HasColumnName("type_vehicule")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Utilise>(entity =>
            {
                entity.HasKey(e => new { e.Vehicule, e.Client, e.Date })
                    .HasName("PRIMARY");

                entity.ToTable("utilise");

                entity.HasIndex(e => e.BorneArrivee)
                    .HasName("fk_utilise_Borne2_idx");

                entity.HasIndex(e => e.BorneDepart)
                    .HasName("fk_utilise_Borne1_idx");

                entity.HasIndex(e => e.Client)
                    .HasName("fk_table1_Client1_idx");

                entity.Property(e => e.Vehicule).HasColumnType("int(11)");

                entity.Property(e => e.Client).HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BorneArrivee)
                    .HasColumnName("borne_arrivee")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BorneDepart)
                    .HasColumnName("borne_depart")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BorneArriveeNavigation)
                    .WithMany(p => p.UtiliseBorneArriveeNavigation)
                    .HasForeignKey(d => d.BorneArrivee)
                    .HasConstraintName("fk_utilise_Borne2");

                entity.HasOne(d => d.BorneDepartNavigation)
                    .WithMany(p => p.UtiliseBorneDepartNavigation)
                    .HasForeignKey(d => d.BorneDepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_utilise_Borne1");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Utilise)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_table1_Client1");

                entity.HasOne(d => d.VehiculeNavigation)
                    .WithMany(p => p.Utilise)
                    .HasForeignKey(d => d.Vehicule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_table1_Vehicule1");
            });

            modelBuilder.Entity<Vehicule>(entity =>
            {
                entity.HasKey(e => e.IdVehicule)
                    .HasName("PRIMARY");

                entity.ToTable("vehicule");

                entity.HasIndex(e => e.Rfid)
                    .HasName("RFID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TypeVehicule)
                    .HasName("fk_Vehicule_Type_vehicule1_idx");

                entity.Property(e => e.IdVehicule)
                    .HasColumnName("idVehicule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Disponibilite)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EtatBatterie)
                    .HasColumnName("etatBatterie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Rfid)
                    .HasColumnName("RFID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypeVehicule)
                    .HasColumnName("type_vehicule")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TypeVehiculeNavigation)
                    .WithMany(p => p.Vehicule)
                    .HasForeignKey(d => d.TypeVehicule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vehicule_Type_vehicule1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
