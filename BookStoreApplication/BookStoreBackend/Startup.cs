using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;

using Manager.AddressManager;
using Manager.LoginManager;
using Manager.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.AddressRepository;
using Repository.DBContext;
using Repository.LoginRepo;
using Repository.Repository;

namespace BookStoreBackend
{
    /// <summary>
    /// startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// contruction class of Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContextPool<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDbConnection")));          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookManager, BookManager>();

            services.AddTransient<IAddressManager, ProductAddressManager>();
            services.AddTransient<IAddressRepository, ProductAddressRepository>();

            services.AddTransient<ICartManager, CartManager>();

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartRepository, CartRepository>();

            services.AddTransient<ICartManager,CartManager>();

            services.AddTransient<ILoginRepo, ImpLoginRepo>();
            services.AddTransient<ILogin,ImpLoginManager>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStoreApplication", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "myapi v1"); });
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
