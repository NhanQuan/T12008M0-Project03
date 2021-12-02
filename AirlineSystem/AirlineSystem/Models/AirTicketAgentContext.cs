using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class AirTicketAgentContext : DbContext
    {
        public AirTicketAgentContext()
        {
        }

        public AirTicketAgentContext(DbContextOptions<AirTicketAgentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AirLine> AirLines { get; set; }
        public virtual DbSet<AirTicket> AirTickets { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDeTail> BillDeTails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Listoforder> Listoforders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=AirTicketAgent;User=sa;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.DisplayName).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountRoleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountRole)
                    .HasConstraintName("FK__Account__Account__267ABA7A");
            });

            modelBuilder.Entity<AirLine>(entity =>
            {
                entity.ToTable("AirLine");

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.AirLineName).HasMaxLength(100);

                entity.Property(e => e.AirLineStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AirTicket>(entity =>
            {
                entity.ToTable("AirTicket");

                entity.Property(e => e.AirTicketId).HasColumnName("AirTicketID");

                entity.Property(e => e.ChairId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ChairID");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.StatusTicket).HasMaxLength(15);

                entity.Property(e => e.TicketCateogry).HasMaxLength(15);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.AirTickets)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__AirTicket__Fligh__33D4B598");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateBillDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OdererNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Oderer)
                    .HasConstraintName("FK__Bill__Oderer__36B12243");
            });

            modelBuilder.Entity<BillDeTail>(entity =>
            {
                entity.ToTable("BillDeTail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.BillDeTails)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK__BillDeTai__Airli__3B75D760");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.BillDeTails)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__BillDeTai__Fligh__3A81B327");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Customer");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Sex)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Customer__Accoun__2A4B4B5E");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Name).HasMaxLength(15);

                entity.Property(e => e.Sex)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Employee__Accoun__286302EC");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.CategoryFlight).HasMaxLength(10);

                entity.Property(e => e.FinalDestination).HasMaxLength(100);

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Ðây là vé m?t chi?u')");

                entity.Property(e => e.StartingPoint).HasMaxLength(100);

                entity.Property(e => e.StatusFlight)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('active')");

                entity.HasOne(d => d.AirLine)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirLineId)
                    .HasConstraintName("FK__Flight__AirLineI__30F848ED");
            });

            modelBuilder.Entity<Listoforder>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AirLineName).HasMaxLength(50);

                entity.Property(e => e.AirTicketId).HasColumnName("AirTicketID");

                entity.Property(e => e.ChairId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ChairID");

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.EmployUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinalDestination).HasMaxLength(50);

                entity.Property(e => e.FlightCategory).HasMaxLength(15);

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.ReturnDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'Đây là vé một chiều')");

                entity.Property(e => e.StartingPoint).HasMaxLength(50);

                entity.Property(e => e.StatusOrder).HasMaxLength(20);

                entity.Property(e => e.TicketCategory).HasMaxLength(15);

                entity.Property(e => e.TimeOrder)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
