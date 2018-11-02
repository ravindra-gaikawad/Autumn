namespace Autumn.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Autumn.API.Models;
    using Autumn.API.Repository;
    using Autumn.API.Services;
    using Autumn.API.UoW;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ActionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<AppSettings>(this.Configuration.GetSection("AppSettings"));

            var builder = new ContainerBuilder();

            PrePopulationRegistration(builder);

            builder.Populate(services);

            PostPopulationRegistration(builder);

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void PrePopulationRegistration(ContainerBuilder builder)
        {
        }

        private static void PostPopulationRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<AutumnDBContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<AutumnDBContextRepository>().As<IRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<BookPageService>().As<IBookPageService>().InstancePerLifetimeScope();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<DiaryPageService>().As<IDiaryPageService>().InstancePerLifetimeScope();
            builder.RegisterType<DiaryService>().As<IDiaryService>().InstancePerLifetimeScope();
            builder.RegisterType<EpisodeService>().As<IEpisodeService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<WishService>().As<IWishService>().InstancePerLifetimeScope();
        }
    }
}
