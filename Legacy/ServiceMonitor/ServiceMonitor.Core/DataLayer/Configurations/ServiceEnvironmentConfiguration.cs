﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Configurations
{
    public class ServiceEnvironmentConfiguration : IEntityTypeConfiguration<ServiceEnvironment>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironment> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceEnvironment", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ServiceEnvironmentID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ServiceEnvironmentID).UseSqlServerIdentityColumn();
        }
    }
}
