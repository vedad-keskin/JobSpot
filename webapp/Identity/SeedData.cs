using AutoMapper;
using Identity.Models;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Identity
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString,  IMapper mapper)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AspIdentityDbContext>(
                options => options.UseSqlServer(connectionString)
            );

            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AspIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddOperationalDbContext(
                options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(
                            connectionString,
                            sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName)
                        );
                }
            );
            services.AddConfigurationDbContext(
                options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(
                            connectionString,
                            sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName)
                        );
                }
            );

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

            var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            context.Database.Migrate();

            EnsureSeedData(context, mapper);

            var ctx = scope.ServiceProvider.GetService<AspIdentityDbContext>();
            ctx.Database.Migrate();
            EnsureUsers(scope);
        }

        private static void EnsureUsers(IServiceScope scope)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = userMgr.FindByNameAsync("belmin").Result;
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "belmin",
                    Email = "belmin.mujan@edu.fit.ba",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(user, "Belmin?123").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result =
                    userMgr.AddClaimsAsync(
                        user,
                        new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, "Belmin Mujan"),
                            new Claim(JwtClaimTypes.GivenName, "Belmin"),
                            new Claim(JwtClaimTypes.FamilyName, "Mujan"),
                            new Claim(JwtClaimTypes.WebSite, ""),
                            new Claim("location", "Sarajevo")
                        }
                    ).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }
        }

        private static void EnsureSeedData(ConfigurationDbContext context, IMapper mapper)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients.ToList())
                {
                    var entityClient = mapper.Map<IdentityServer4.EntityFramework.Entities.Client>(client);
                    context.Clients.Add(entityClient);
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources.ToList())
                {
                    //context.IdentityResources.Add(resource.ToEntity());
                    var entityClient = mapper.Map<IdentityServer4.EntityFramework.Entities.IdentityResource>(resource);
                    context.IdentityResources.Add(entityClient);
                }

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes.ToList())
                {
                    //context.ApiScopes.Add(resource.ToEntity());
                    var entityClient = mapper.Map<IdentityServer4.EntityFramework.Entities.ApiScope>(resource);
                    context.ApiScopes.Add(entityClient);
                }

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources.ToList())
                {
                    //context.ApiResources.Add(resource.ToEntity());
                    var entityClient = mapper.Map<IdentityServer4.EntityFramework.Entities.ApiResource>(resource);
                    context.ApiResources.Add(entityClient);
                }

                context.SaveChanges();
            }
        }
    }
}