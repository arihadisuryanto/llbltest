﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.11.</auto-generated>
//------------------------------------------------------------------------------
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using llbltest.EntityClasses;

namespace llbltest
{
	/// <summary>Model builder class for code first development.</summary>
	public partial class LlbltestModelBuilder
	{
		/// <summary>Builds the model defined in this class with the modelbuilder specified. Called from the generated DbContext</summary>
		/// <param name="modelBuilder">The model builder to build the model with.</param>
		public virtual void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			MapAttachment(modelBuilder.Entity<Attachment>());
			MapDealer(modelBuilder.Entity<Dealer>());
			MapOwner(modelBuilder.Entity<Owner>());
			MapPenjualan(modelBuilder.Entity<Penjualan>());
			MapSalesman(modelBuilder.Entity<Salesman>());
		}

		/// <summary>Defines the mapping information for the entity 'Attachment'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapAttachment(EntityTypeBuilder<Attachment> config)
		{
			config.ToTable("Attachment");
			config.HasKey(t => t.Id);
			config.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
			config.Property(t => t.EntityId).HasColumnName("EntityID");
			config.Property(t => t.EntityType);
			config.Property(t => t.CloudUrl).HasColumnName("CloudURL");
			config.Property(t => t.MimeType);
			config.Property(t => t.FileName);
		}

		/// <summary>Defines the mapping information for the entity 'Dealer'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapDealer(EntityTypeBuilder<Dealer> config)
		{
			config.ToTable("Dealer");
			config.HasKey(t => t.Id);
			config.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
			config.Property(t => t.DealerName).HasMaxLength(50);
			config.Property(t => t.OwnerId).HasColumnName("OwnerID");
			config.HasOne(t => t.Owner).WithMany(t => t.Dealers).HasForeignKey(t => t.OwnerId);
		}

		/// <summary>Defines the mapping information for the entity 'Owner'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapOwner(EntityTypeBuilder<Owner> config)
		{
			config.ToTable("Owner");
			config.HasKey(t => t.Id);
			config.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
			config.Property(t => t.OwnerName).HasMaxLength(50);
		}

		/// <summary>Defines the mapping information for the entity 'Penjualan'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapPenjualan(EntityTypeBuilder<Penjualan> config)
		{
			config.ToTable("Penjualan");
			config.HasKey(t => t.Id);
			config.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
			config.Property(t => t.CustomerId).HasColumnName("CustomerID");
			config.Property(t => t.TransactionDate);
		}

		/// <summary>Defines the mapping information for the entity 'Salesman'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapSalesman(EntityTypeBuilder<Salesman> config)
		{
			config.ToTable("Salesman");
			config.HasKey(t => t.Id);
			config.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
			config.Property(t => t.SalesName).HasMaxLength(50);
			config.Property(t => t.DealerId).HasColumnName("DealerID");
			config.HasOne(t => t.Dealer).WithMany(t => t.Salesmen).HasForeignKey(t => t.DealerId);
		}
	}


	/// <summary>Extensions class for extension methods used in the model builder code</summary>
	internal static partial class LlbltestModelBuilderExtensions
	{
		private static readonly string READONLY_ANNOTATION = "custom:readonly";

		/// <summary>Extension method which is used by the context class to determine whether an entity is readonly</summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="builder">The entity type builder object to augment.</param>
		/// <returns>the passed in entity type builder</returns>
		internal static EntityTypeBuilder<TEntity> IsReadOnly<TEntity>(this EntityTypeBuilder<TEntity> builder)
			where TEntity : class
		{
			builder.HasAnnotation(READONLY_ANNOTATION, true);
			return builder;
		}
		
		/// <summary>Determines whether the passed in entity type has the readonly annotation set.
		/// </summary>
		/// <param name="entity">The entity type to check.</param>
		/// <returns>true if the entity type is marked as read-only, false otherwise</returns>
		public static bool IsReadOnly(this IEntityType entity)
		{
			var annotation = entity.FindAnnotation(READONLY_ANNOTATION);
			return annotation != null && (bool)annotation.Value;
		}
	}
}

