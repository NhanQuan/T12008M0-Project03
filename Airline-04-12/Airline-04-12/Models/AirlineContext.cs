using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Airline_04_12.Models
{
    public partial class AirlineContext : DbContext
    {
        public AirlineContext()
        {
        }

        public AirlineContext(DbContextOptions<AirlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Airline;User=sa;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_user");

                entity.ToTable("account");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Create_at");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Create_by");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Passport)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Update_at");

                entity.Property(e => e.UpdateBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Update_by");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_role");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Create_at");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Create_by");

                entity.Property(e => e.Detail).HasColumnType("text");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Update_at");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Update_by");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_news_account");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.TicketId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_Order_ticket1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_user");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.TicketId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AirlineImg)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Create_at");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Create_by");

                entity.Property(e => e.DepartureAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlightCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TicketType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Update_at");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Update_by");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ticket_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
