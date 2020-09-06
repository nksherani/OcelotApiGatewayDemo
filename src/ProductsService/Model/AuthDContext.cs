//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ProductsService.Model
//{
//    public class AuthDContext : DbContext
//    {
//        public AuthDContext(DbContextOptions<AuthDContext> options) : base(options)
//        {

//        }

//        public DbSet<ClientEntity> Clients { get; set; }
//        public DbSet<ApiResourceEntity> ApiResources { get; set; }
//        public DbSet<IdentityResourceEntity> IdentityResources { get; set; }
//        public DbSet<ScopeEntity> Scopes { get; set; }


//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.Entity<ClientEntity>().HasKey(m => m.ClientId);
//            builder.Entity<ApiResourceEntity>().HasKey(m => m.ApiResourceName);
//            builder.Entity<IdentityResourceEntity>().HasKey(m => m.IdentityResourceName);
//            base.OnModelCreating(builder);
//        }
//    }
//}
