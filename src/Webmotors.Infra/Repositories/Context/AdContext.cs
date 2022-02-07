using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Webmotors.Infra.Extensions;

namespace Webmotors.Infra.Repositories.Context
{
    public partial class AdContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public AdContext(DbContextOptions<AdContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type[] types = typeof(EntityTypeConfiguration<>).GetTypeInfo().Assembly.GetTypes();
            IEnumerable<Type> typesToRegister = types
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                type.GetTypeInfo().BaseType != null &&
                                type.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType &&
                                type.GetTypeInfo().BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                ModelBuilderExtensions.AddConfiguration(modelBuilder, configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();
            var items = new Dictionary<object, object>();
            foreach (var entry in this.ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;
                var context = new ValidationContext(entity, serviceProvider, items);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                        if (result != ValidationResult.Success)
                            throw new ValidationException(result.ErrorMessage);
                }
            }
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
