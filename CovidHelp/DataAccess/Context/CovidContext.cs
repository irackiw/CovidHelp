using CovidHelp.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace CovidHelp.DataAccess.Context
{
    public partial class CovidContext : DbContext
    {
        public CovidContext(DbContextOptions<CovidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAppliedOffer> UserAppliedOffer { get; set; }
        public virtual DbSet<UserOffer> UserOffer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("offer");

                entity.HasIndex(e => e.PhotoId)
                    .HasName("photo_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(11)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PhotoId)
                    .HasColumnName("photo_id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ValidTo)
                    .HasColumnName("valid_to")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("offer_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");


                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .IsRequired()
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Pesel)
                    .HasColumnName("pesel")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserAppliedOffer>(entity =>
            {
                entity.ToTable("user_applied_offer");

                entity.HasIndex(e => e.OfferId)
                    .HasName("offer_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.UserAppliedOffer)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("user_applied_offer_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAppliedOffer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_applied_offer_ibfk_1");
            });

            modelBuilder.Entity<UserOffer>(entity =>
            {
                entity.ToTable("user_offer");

                entity.HasIndex(e => e.OfferId)
                    .HasName("offer_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.UserOffer)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("user_offer_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOffer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_offer_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
