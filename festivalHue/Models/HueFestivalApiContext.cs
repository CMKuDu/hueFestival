using System;
using System.Collections.Generic;
using ChatGPT.Net.DTO.ChatGPTUnofficial;
using Microsoft.EntityFrameworkCore;

namespace festivalHue.Models;

public partial class HueFestivalApiContext : DbContext
{
    private readonly HueFestivalApiContext _context;
    public HueFestivalApiContext(HueFestivalApiContext context)
    {
        _context = context;
    }

    public HueFestivalApiContext(DbContextOptions<HueFestivalApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deatailbookticket> Deatailbooktickets { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<News> News { get; set; } 

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticketbook> Ticketbooks { get; set; }

    public virtual DbSet<Tickettype> Tickettypes { get; set; }

    public virtual DbSet<Transacstatus> Transacstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("server=DESKTOP-CLB8QVO;database=hueFestivalApi;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Idaccount).HasName("PK__ACCOUNT__F3DEE7EFCBFD0CC9");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Idaccount).HasColumnName("IDACCOUNT");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Idrole).HasColumnName("IDROLE");
            entity.Property(e => e.Lastlogin)
                .HasColumnType("datetime")
                .HasColumnName("LASTLOGIN");
            entity.Property(e => e.Nameaccount)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NAMEACCOUNT");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone).HasColumnName("PHONE");
            entity.Property(e => e.Salt)
                .HasMaxLength(50)
                .HasColumnName("SALT");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Idrole)
                .HasConstraintName("FK_ACCOUNT_ROLE");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer).HasName("PK__CUSTOMER__1AD2CC47BEDBA549");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Idcustomer).HasColumnName("IDCUSTOMER");
            entity.Property(e => e.Addresscustomer)
                .HasMaxLength(100)
                .HasColumnName("ADDRESSCUSTOMER");
            entity.Property(e => e.Avatar)
                .HasMaxLength(250)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Birthdaycustomer)
                .HasColumnType("datetime")
                .HasColumnName("BIRTHDAYCUSTOMER");
            entity.Property(e => e.Emailcustomer)
                .HasMaxLength(50)
                .HasColumnName("EMAILCUSTOMER");
            entity.Property(e => e.Idlocation).HasColumnName("IDLOCATION");
            entity.Property(e => e.Namecustomer)
                .HasMaxLength(50)
                .HasColumnName("NAMECUSTOMER");
            entity.Property(e => e.Phonecustomer)
                .HasMaxLength(12)
                .HasColumnName("PHONECUSTOMER");

            entity.HasOne(d => d.IdlocationNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Idlocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUSTOMER_LOCATION");
        });

        modelBuilder.Entity<Deatailbookticket>(entity =>
        {
            entity.HasKey(e => e.Idcustomer);

            entity.ToTable("DEATAILBOOKTICKET");

            entity.Property(e => e.Idcustomer)
                .ValueGeneratedNever()
                .HasColumnName("IDCUSTOMER");
            entity.Property(e => e.Idbook).HasColumnName("IDBOOK");
            entity.Property(e => e.Idstatus).HasColumnName("IDSTATUS");

            entity.HasOne(d => d.IdcustomerNavigation).WithOne(p => p.Deatailbookticket)
                .HasForeignKey<Deatailbookticket>(d => d.Idcustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEATAILBOOKTICKET_CUSTOMER");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Idevent).HasName("PK__EVENT__2868B545F2374CBA");

            entity.ToTable("EVENT");

            entity.Property(e => e.Idevent).HasColumnName("IDEVENT");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .HasColumnName("ALIAS");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Nameevent)
                .HasMaxLength(100)
                .HasColumnName("NAMEEVENT");
            entity.Property(e => e.Puslish).HasColumnName("PUSLISH");
            entity.Property(e => e.Thumb)
                .HasMaxLength(200)
                .HasColumnName("THUMB");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Idlocation).HasName("PK__LOCATION__09CF6979980EDE6B");

            entity.ToTable("LOCATION");

            entity.Property(e => e.Idlocation).HasColumnName("IDLOCATION");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("DISTRICT");
            entity.Property(e => e.Namelocation)
                .HasMaxLength(50)
                .HasColumnName("NAMELOCATION");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Idnews).HasName("PK__NEWS__3FFED9CA1D1FA3E7");

            entity.ToTable("NEWS");

            entity.Property(e => e.Idnews).HasColumnName("IDNEWS");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .HasColumnName("ALIAS");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .HasColumnName("AUTHOR");
            entity.Property(e => e.Content).HasColumnName("CONTENT");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole).HasName("PK__ROLE__8A7E91124D46C7A7");

            entity.ToTable("ROLE");

            entity.Property(e => e.Idrole).HasColumnName("IDROLE");
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
            entity.HasKey(e => e.Idticket).HasName("PK__TICKET__D4E664EDCEB8F3D2");

            entity.ToTable("TICKET");

            entity.Property(e => e.Idticket).HasColumnName("IDTICKET");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.Bestseller).HasColumnName("BESTSELLER");
            entity.Property(e => e.Datecreate)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATE");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Idtypeticket).HasColumnName("IDTYPETICKET");
            entity.Property(e => e.Nameticket)
                .HasMaxLength(100)
                .HasColumnName("NAMETICKET");
            entity.Property(e => e.Priceticket).HasColumnName("PRICETICKET");
            entity.Property(e => e.Timeeffective)
                .HasColumnType("datetime")
                .HasColumnName("TIMEEFFECTIVE");
            entity.Property(e => e.Untistock).HasColumnName("UNTISTOCK");

            entity.HasOne(d => d.IdtypeticketNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Idtypeticket)
                .HasConstraintName("FK_TICKET_TICKETTYPE");
        });

        modelBuilder.Entity<Ticketbook>(entity =>
        {
            entity.HasKey(e => new { e.Idbook, e.Idtransacstatus }).HasName("PK__TICKETBO__9F311EDD98DFA12E");

            entity.ToTable("TICKETBOOK");

            entity.Property(e => e.Idbook)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDBOOK");
            entity.Property(e => e.Idtransacstatus).HasColumnName("IDTRANSACSTATUS");
            entity.Property(e => e.Datecreatebook)
                .HasColumnType("datetime")
                .HasColumnName("DATECREATEBOOK");
            entity.Property(e => e.Datepay)
                .HasColumnType("datetime")
                .HasColumnName("DATEPAY");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCUSTOMER");
            entity.Property(e => e.Money).HasColumnName("MONEY");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .HasColumnName("NOTE");

            entity.HasOne(d => d.IdbookNavigation).WithMany(p => p.Ticketbooks)
                .HasForeignKey(d => d.Idbook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TICKETBOOK_DEATAILBOOKTICKET1");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.Ticketbooks)
                .HasForeignKey(d => d.Idcustomer)
                .HasConstraintName("FK_TICKETBOOK_CUSTOMER");

            entity.HasOne(d => d.IdtransacstatusNavigation).WithMany(p => p.Ticketbooks)
                .HasForeignKey(d => d.Idtransacstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TICKETBOOK_TRANSACSTATUS");
        });

        modelBuilder.Entity<Tickettype>(entity =>
        {
            entity.HasKey(e => e.Idtypeticket).HasName("PK__TICKETTY__08775F588224DAF6");

            entity.ToTable("TICKETTYPE");

            entity.Property(e => e.Idtypeticket).HasColumnName("IDTYPETICKET");
            entity.Property(e => e.Aliasticket)
                .HasMaxLength(50)
                .HasColumnName("ALIASTICKET");
            entity.Property(e => e.Descriptionticket)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPTIONTICKET");
            entity.Property(e => e.Nametypeticket)
                .HasMaxLength(100)
                .HasColumnName("NAMETYPETICKET");
            entity.Property(e => e.Puslish).HasColumnName("PUSLISH");
        });

        modelBuilder.Entity<Transacstatus>(entity =>
        {
            entity.HasKey(e => e.Idtransacstatus).HasName("PK__TRANSACS__A0E7F78D02026077");

            entity.ToTable("TRANSACSTATUS");

            entity.Property(e => e.Idtransacstatus).HasColumnName("IDTRANSACSTATUS");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("STATUS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
