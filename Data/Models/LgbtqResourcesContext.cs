using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LgbtqResources.Data.Models;

public partial class LgbtqResourcesContext : DbContext
{
    //Scaffold-DbContext "Server=server.stegeman.trey,1433;Database=LgbtqResources;User Id=Test;Password=SQ1S3rv3r;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Data/Models

    public LgbtqResourcesContext()
    {
    }

    public LgbtqResourcesContext(DbContextOptions<LgbtqResourcesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catagory> Catagories { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Subcatagory> Subcatagories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=server.stegeman.trey,1433;Database=LgbtqResources;User Id=Test;Password=SQ1S3rv3r;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catagory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catagori__3214EC0791AED195");

            entity.HasOne(d => d.Group).WithMany(p => p.Catagories)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catagories_To_Groups");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC07D53017E9");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC0744785158");

            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Subcatagory).WithMany(p => p.Resources)
                .HasForeignKey(d => d.SubcatagoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subcatagories_To_Resources");
        });

        modelBuilder.Entity<Subcatagory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subcatag__3214EC07BBF05EF3");

            entity.HasOne(d => d.Catagory).WithMany(p => p.Subcatagories)
                .HasForeignKey(d => d.CatagoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catagories_To_Subcatagories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
