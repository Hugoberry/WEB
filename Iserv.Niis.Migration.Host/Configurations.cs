﻿using Iserv.OldNiis.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using Iserv.Niis.Migration.BusinessLogic;
using Iserv.Niis.Migration.BusinessLogic.Abstract;
using Iserv.Niis.Business.Abstract;
using Iserv.Niis.Business.Implementations;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Iserv.Niis.FileStorage.Abstract;
using Iserv.Niis.FileStorage.Implementations;
using Microsoft.Extensions.Configuration;
using Iserv.Niis.Utils.Abstractions;
using Iserv.Niis.Utils.Implementations;
using Iserv.Niis.Migration.BusinessLogic.Models;
using Iserv.Niis.Migration.Host.Constants;
using Iserv.Niis.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Iserv.Niis.Infrastructure.Infrastructure.Security;
using Iserv.Niis.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Iserv.Niis.Migration.Host
{
    public static class Configurations
    {
        public static IServiceProvider ConfigurationDependencies()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            var appConfiguration = GetAppConfiguration();
            services.AddSingleton<AppConfiguration>(appConfiguration);

            RegisterContexts(services, appConfiguration);
            RegisterAuthoriazation(services, configuration);
            RegisterMigrationBusinessLogic(services);
            RegisterLogger(services);
            RegisterOtherServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddNLog(new NLogProviderOptions
            {
                CaptureMessageTemplates = true,
                CaptureMessageProperties = true
            });

            NLog.LogManager.LoadConfiguration("NLog.config");

            return serviceProvider;
        }

        #region Private methods
        private static void RegisterContexts(IServiceCollection serviceCollection, AppConfiguration appConfiguration)
        {
            serviceCollection
                .AddDbContextPool<NiisWebContextMigration>(options => options.UseSqlServer(appConfiguration.NiisConnectionString))
                .AddDbContextPool<OldNiisContext>(options => options.UseSqlServer(appConfiguration.OldNiisConnectionString))
                .AddDbContextPool<OldNiisFileContext>(options => options.UseSqlServer(appConfiguration.OldNiisFileConnectionString), 248)
                .AddTransient<DbContext, NiisWebContextMigration>()
                .AddTransient<DbContext, OldNiisContext>()
                .AddTransient<DbContext, OldNiisFileContext>();
        }
        private static void RegisterMigrationBusinessLogic(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<AssemblyPointerBusinessLogic>()
                .AddClasses(classes => classes.AssignableTo<BaseHandler>())
                .AsSelf()
                .WithTransientLifetime());

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<AssemblyPointerBusinessLogic>()
                .AddClasses(classes => classes.AssignableTo<BaseService>())
                .AsSelf()
                .WithTransientLifetime());

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<AssemblyPointerBusinessLogic>()
                .AddClasses(classes => classes.AssignableTo<BaseHelper>())
                .AsSelf()
                .WithTransientLifetime());
        }

        private static void RegisterOtherServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IDicTypeResolver, DicTypeResolver>()
                .AddTransient<IFileStorage, MinioFileStorage>()
                .AddTransient<IGenerateHash, GenerateHash>()
                .AddTransient<MigrateAllData>()
                .AddTransient<MigrateAttachments>();
        }

        private static void RegisterLogger(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
            serviceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            serviceCollection.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));
        }

        private static void RegisterAuthoriazation(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
            serviceCollection.AddTransient<IJwtFactory, JwtFactory>();
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => ConfigurationOptions.JwtBearerOptions(options, configuration));
            serviceCollection.AddIdentity<ApplicationUser, ApplicationRole>(ConfigurationOptions.IdentityOptions).AddEntityFrameworkStores<NiisWebContextMigration>();
        }

        private static AppConfiguration GetAppConfiguration()
        {
            return new AppConfiguration
            {
                AuthorAttachmentDocumentId = Convert.ToInt32(ConfigurationManager.AppSettings[AppSettings.AuthorAttachmentDocumentId]),
                PackageSize = Convert.ToInt32(ConfigurationManager.AppSettings[AppSettings.PackageSize]),
                BigPackageSize = Convert.ToInt32(ConfigurationManager.AppSettings[AppSettings.BigPackageSize]),
                PackageSizeForFile = Convert.ToInt32(ConfigurationManager.AppSettings[AppSettings.PackageSizeForFile]),
                NiisConnectionString = ConfigurationManager.AppSettings[AppSettings.NiisConnectionString],
                OldNiisConnectionString = ConfigurationManager.AppSettings[AppSettings.OldNiisConnectionString],
                OldNiisFileConnectionString = ConfigurationManager.AppSettings[AppSettings.OldNiisFileConnectionString],
                MainExecutorId = Convert.ToInt32(ConfigurationManager.AppSettings[AppSettings.MainExecutorId]),
            };
        }
        #endregion

    }
}
