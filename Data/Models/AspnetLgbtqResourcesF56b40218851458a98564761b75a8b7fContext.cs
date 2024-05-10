using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LgbtqResources.Data.Models;

public partial class AspnetLgbtqResourcesF56b40218851458a98564761b75a8b7fContext : DbContext
{
    //Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=aspnet-LgbtqResources-f56b4021-8851-458a-9856-4761b75a8b7f;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Data/Models
    public AspnetLgbtqResourcesF56b40218851458a98564761b75a8b7fContext()
    {
    }

    public AspnetLgbtqResourcesF56b40218851458a98564761b75a8b7fContext(DbContextOptions<AspnetLgbtqResourcesF56b40218851458a98564761b75a8b7fContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catagory> Catagories { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Subcatagory> Subcatagories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-LgbtqResources-f56b4021-8851-458a-9856-4761b75a8b7f;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Catagory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07A9798DC7");

            entity.HasOne(d => d.Group).WithMany(p => p.Catagories)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catagories_To_Groups");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07686A74B0");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC0721F15384");

            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Subcatagory).WithMany(p => p.Resources)
                .HasForeignKey(d => d.SubcatagoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subcatagories_To_Resources");
        });

        modelBuilder.Entity<Subcatagory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subcatag__3214EC07D8C56DD5");

            entity.HasOne(d => d.Catagory).WithMany(p => p.Subcatagories)
                .HasForeignKey(d => d.CatagoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catagories_To_Subcatagories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
