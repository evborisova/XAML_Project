using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Consultant.Options;
using Consultant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Swashbuckle;
using Microsoft.OpenApi.Models;
using SwaggerOptions = Consultant.Options.SwaggerOptions;
using Consultant.Services;

namespace Consultant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Good morning! ʘ‿ʘ

        // This is a string thats used to refer to the CORS policy used in (1) and (2).
        // See (1) next.
        readonly string EnableCors = "_enableCors";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // (1): This defines the CORS policy; and it says to allow all connestions from
                // a server running on http or https://localhost:4200. In our case it will allow
                // all connections from the Consultant Angular app running on localhost.
                // See (2) next.

                // NOTE: This was changed from  http://localhost:5100/api/v1 to http://localhost:4200 because
                // the former would only apply to requests made from the web API itself, as it is running on :5100.
                // Also the specific URL (api/v1) doesn't work for some reason, so only the host and port is specified.

                options.AddPolicy(EnableCors, builder =>
                    {
                        builder.WithOrigins("https://localhost:4200",
                                            "http://localhost:4200",
                                            "https://localhost:500",
                                            "http://localhost:500")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddMvc();

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            /*
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            */

            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Our API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = SwaggerOptions.JsonRoute; });
            //app.UseSwagger();
            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint(SwaggerOptions.UiEndpoint, SwaggerOptions.Description);
               // option.RoutePrefix = string.Empty;
            });

            app.UseRouting();
           
            // (2): Add the CORS policy defined above on the APIs used in this application, so that
            // specific parts of the application can choose to enable the CORS policy.
            
            // So: We can now apply the CORS policy name ('_enableCors') on specific controllers to allow them
            // to work when requests arriving from the Angular app.

            // See (3) in PlannersControllers.cs.
            app.UseCors(EnableCors);


            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

           // app.UseStaticFiles();

        }

            //app.UseHttpsRedirection();


            //app.UseAuthorization();


        }
    }

