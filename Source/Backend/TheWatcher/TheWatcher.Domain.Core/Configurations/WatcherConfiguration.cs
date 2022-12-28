using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Configurations.Common;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class WatcherConfiguration : EntityConfiguration<Watcher>
	{
		public override void Configure(EntityTypeBuilder<Watcher> builder)
		{
			base.Configure(builder);

			// Set configuration for entity
			builder.ToTable("Watcher", "dbo");

			// Set key for entity
			builder.HasKey(p => p.Id);

			// Set identity for entity (auto increment)
			builder.Property(p => p.Id).UseIdentityColumn();

			// Set configuration for columns
			builder
				.Property(p => p.Id)
				.HasColumnType("smallint")
				.IsRequired()
				;

			builder
				.Property(p => p.Guid)
				.IsRequired()
				;

			builder
				.Property(p => p.AssemblyQualifiedName)
				.HasColumnType("nvarchar")
				.HasMaxLength(511)
				.IsRequired()
				;

			builder
				.Property(p => p.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired()
				;

			builder
				.Property(p => p.Description)
				.HasColumnType("nvarchar(max)")
				;

			// Add configuration for uniques

			builder
				.HasIndex(p => p.Guid)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_Watcher_Guid")
				;

			builder
				.HasIndex(p => p.AssemblyQualifiedName)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_Watcher_AssemblyQualifiedName")
				;

			builder
				.HasIndex(p => p.Name)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_Watcher_Name")
				;
		}
	}
}
