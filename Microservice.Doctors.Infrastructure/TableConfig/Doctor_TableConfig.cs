using Microservice.Doctors.Domain.Doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Doctors.Infrastructure.TableConfig
{
    public class Doctor_TableConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Credential).HasColumnName("Credential").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).HasField("_name");
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50).HasField("_lastname");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.Specialty).HasColumnName("Specialty").HasMaxLength(50).HasField("_specialty");

            builder.OwnsOne(u => u.Phone, phoneBuilder =>
            {
                phoneBuilder.Property(e => e.Value)
                            .HasColumnName("phone")
                            .HasMaxLength(50)
                            .IsRequired();
                phoneBuilder.HasIndex(e => e.Value).IsUnique();
            });
            builder.OwnsOne(u => u.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Value)
                            .HasColumnName("email")
                            .HasMaxLength(50)
                            .IsRequired();
                emailBuilder.HasIndex(e => e.Value).IsUnique();
            });
            builder.OwnsOne(u => u.Password, passBuilder =>
            {
                passBuilder.Property(e => e.Value)
                            .HasColumnName("password")
                            .HasMaxLength(50)
                            .IsRequired();
                passBuilder.HasIndex(e => e.Value).IsUnique();
            });

        }
    }
}
