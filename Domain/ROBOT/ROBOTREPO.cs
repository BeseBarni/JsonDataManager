using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.ROBOT;

public partial class ROBOTREPO : DbContext
{
    public ROBOTREPO()
    {
    }

    public ROBOTREPO(DbContextOptions<ROBOTREPO> options)
        : base(options)
    {
    }


    public virtual DbSet<Crime> Crime { get; set; }

    public virtual DbSet<Robots> Robots { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=adatb-mssql.mik.uni-pannon.hu,2019;initial catalog=h42_z7i1ac; User Id=h42_z7i1ac; Password=#t-BQ_2CXA; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Crime>(entity =>
        {
            entity.HasKey(e => e.c_id);

            entity.Property(e => e.neighbourhood)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.type)
                .HasMaxLength(200)
                .IsFixedLength();

            entity.HasOne(d => d.r_idNavigation).WithMany(p => p.Crime)
                .HasForeignKey(d => d.r_id)
                .HasConstraintName("FK_Crime_Robots");
        });

        modelBuilder.Entity<Robots>(entity =>
        {
            entity.HasKey(e => e.r_id);

            entity.Property(e => e.first)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.gender)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.last)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsFixedLength();
        });




      







        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
