using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace festivalHue.Models;

public partial class HueContext : DbContext
{
    public HueContext()
    {
    }

    public HueContext(DbContextOptions<HueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticketbook> Ticketbooks { get; set; }

    public virtual DbSet<Tickettype> Tickettypes { get; set; }

    public virtual DbSet<Transacstatus> Transacstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CLB8QVO;Database=Hue;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => new { e.Idaccount, e.Idrole });

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Idaccount).HasColumnName("IDACCOUNT");
            entity.Property(e => e.Idrole).HasColumnName("IDROLE");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Email)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("EMAIL");
            entity.Property(e => e.Lastlogin)
                .HasColumnType("datetime")
                .HasColumnName("LASTLOGIN");
            entity.Property(e => e.Nameaccount)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NAMEACCOUNT");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONE");
            entity.Property(e => e.Salt)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("SALT");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Idrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RELATIONSHIP3");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => new { e.Idcustomer, e.Idlocation });

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Idcustomer).HasColumnName("IDCUSTOMER");
            entity.Property(e => e.Idlocation).HasColumnName("IDLOCATION");
            entity.Property(e => e.Addresscustomer)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("ADDRESSCUSTOMER");
            entity.Property(e => e.Avatar)
                .HasColumnType("image")
                .HasColumnName("AVATAR");
            entity.Property(e => e.Birthdaycustomer)
                .HasColumnType("datetime")
                .HasColumnName("BIRTHDAYCUSTOMER");
            entity.Property(e => e.Emailcustomer)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("EMAILCUSTOMER");
            entity.Property(e => e.Namecustomer)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("NAMECUSTOMER");
            entity.Property(e => e.Phonecustomer)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("PHONECUSTOMER");

            entity.HasOne(d => d.IdlocationNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Idlocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RELATIONSHIP25");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => new { e.Idevent, e.Idaccount, e.Idrole });

            entity.ToTable("EVENT");

            entity.Property(e => e.Idevent).HasColumnName("IDEVENT");
            entity.Property(e => e.Idaccount).HasColumnName("IDACCOUNT");
            entity.Property(e => e.Idrole).HasColumnName("IDROLE");
            entity.Property(e => e.Alias)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("ALIAS");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Nameevent)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("NAMEEVENT");
            entity.Property(e => e.Puslish)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PUSLISH");
            entity.Property(e => e.Thumb)
                .HasColumnType("image")
                .HasColumnName("THUMB");

            entity.HasOne(d => d.Id).WithMany(p => p.Events)
                .HasForeignKey(d => new { d.Idaccount, d.Idrole })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RELATIONSHIP5");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Idlocation);

            entity.ToTable("LOCATION");

            entity.Property(e => e.Idlocation)
                .ValueGeneratedNever()
                .HasColumnName("IDLOCATION");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Namelocation)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("NAMELOCATION");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => new { e.Idnews, e.Idaccount, e.Idrole });

            entity.ToTable("NEWS");

            entity.Property(e => e.Idnews).HasColumnName("IDNEWS");
            entity.Property(e => e.Idaccount).HasColumnName("IDACCOUNT");
            entity.Property(e => e.Idrole).HasColumnName("IDROLE");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ALIAS");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("AUTHOR");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Id).WithMany(p => p.News)
                .HasForeignKey(d => new { d.Idaccount, d.Idrole })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RELATIONSHIP4");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole);

            entity.ToTable("ROLE");

            entity.Property(e => e.Idrole)
                .ValueGeneratedNever()
                .HasColumnName("IDROLE");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Namerole)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NAMEROLE");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Idticket);

            entity.ToTable("TICKET");

            entity.Property(e => e.Idticket)
                .ValueGeneratedNever()
                .HasColumnName("IDTICKET");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Bestseller)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BESTSELLER");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Discount)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("DISCOUNT");
            entity.Property(e => e.Idtypeticket).HasColumnName("IDTYPETICKET");
            entity.Property(e => e.Nameticket)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("NAMETICKET");
            entity.Property(e => e.Priceticket)
                .HasColumnType("money")
                .HasColumnName("PRICETICKET");
            entity.Property(e => e.Timeeffective)
                .HasColumnType("datetime")
                .HasColumnName("TIMEEFFECTIVE");
            entity.Property(e => e.Untistock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UNTISTOCK");

            entity.HasOne(d => d.IdtypeticketNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Idtypeticket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RELATIONSHIP11");
        });

        modelBuilder.Entity<Ticketbook>(entity =>
        {
            entity.HasKey(e => new { e.Idbook, e.Idtransacstatus });

            entity.ToTable("TICKETBOOK");

            entity.Property(e => e.Idbook).HasColumnName("IDBOOK");
            entity.Property(e => e.Idtransacstatus).HasColumnName("IDTRANSACSTATUS");
            entity.Property(e => e.Datecreatebook)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATEBOOK");
            entity.Property(e => e.Datepay)
                .HasColumnType("datetime")
                .HasColumnName("DATEPAY");
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Money)
                .HasColumnType("money")
                .HasColumnName("MONEY");
            entity.Property(e => e.Note)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("NOTE");

            entity.HasOne(d => d.IdtransacstatusNavigation).WithMany(p => p.Ticketbooks)
                .HasForeignKey(d => d.Idtransacstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RELATIONSHIP22");

            entity.HasMany(d => d.Ids).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "Deatailbookticket",
                    r => r.HasOne<Customer>().WithMany()
                        .HasForeignKey("Idcustomer", "Idlocation")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("RELATIONSHIP24"),
                    l => l.HasOne<Ticketbook>().WithMany()
                        .HasForeignKey("Idbook", "Idstatus")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("RELATIONSHIP23"),
                    j =>
                    {
                        j.HasKey("Idbook", "Idstatus", "Idcustomer", "Idlocation");
                        j.ToTable("DEATAILBOOKTICKET");
                        j.IndexerProperty<int>("Idbook").HasColumnName("IDBOOK");
                        j.IndexerProperty<int>("Idstatus").HasColumnName("IDSTATUS");
                        j.IndexerProperty<int>("Idcustomer").HasColumnName("IDCUSTOMER");
                        j.IndexerProperty<int>("Idlocation").HasColumnName("IDLOCATION");
                    });
        });

        modelBuilder.Entity<Tickettype>(entity =>
        {
            entity.HasKey(e => e.Idtypeticket);

            entity.ToTable("TICKETTYPE");

            entity.Property(e => e.Idtypeticket)
                .ValueGeneratedNever()
                .HasColumnName("IDTYPETICKET");
            entity.Property(e => e.Aliasticket)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ALIASTICKET");
            entity.Property(e => e.Descriptionticket)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("DESCRIPTIONTICKET");
            entity.Property(e => e.Nametypeticket)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("NAMETYPETICKET");
            entity.Property(e => e.Puslish)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PUSLISH");
        });

        modelBuilder.Entity<Transacstatus>(entity =>
        {
            entity.HasKey(e => e.Idtransacstatus);

            entity.ToTable("TRANSACSTATUS");

            entity.Property(e => e.Idtransacstatus)
                .ValueGeneratedNever()
                .HasColumnName("IDTRANSACSTATUS");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("STATUS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
