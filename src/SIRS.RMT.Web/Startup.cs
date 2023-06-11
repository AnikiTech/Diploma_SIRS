using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using SIRS.RMT.Config;
using System;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace SIRS.RMT.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration.Get<ReadingMemoryThinkingConfiguration>();
        }

        public ReadingMemoryThinkingConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.RegisterApplicationServices()
                    .AddSirsAppEntityFramework(this.Configuration)
                    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                    .AddScoped<IMapper>(provider => new Mapper(provider.GetRequiredService<IConfigurationProvider>(), provider.GetService))
                ;

            _ = services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "rmt/dist"; });

            // Enable CORS
            _ = services.AddCors(options =>
                             {
                                 options.AddDefaultPolicy(builder =>
                                                              builder.SetIsOriginAllowed(_ => true)
                                                                     .AllowAnyMethod()
                                                                     .AllowAnyHeader()
                                                                     .AllowCredentials());
                             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfigurationProvider configurationProvider)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();

                // Check Automapper configuration
                configurationProvider.AssertConfigurationIsValid();
            }
            else
            {
                _ = app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            _ = app.UseCors();
            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context => { context.Context.Response.Headers[HeaderNames.CacheControl] = "must-revalidate"; }
            });
            app.UseSpaStaticFiles();
            _ = app.Use(async (context, next) =>
                    {
                        // Disable caching all GET or HEAD requests
                        if (HttpMethods.IsGet(context.Request.Method) || HttpMethods.IsHead(context.Request.Method))
                        {
                            context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                            {
                                NoStore = true,
                                NoCache = true
                            };
                        }

                        await next.Invoke();
                    });
            _ = app.UseRouting();

            _ = app.UseEndpoints(endpoints =>
                             {
                                 _ = endpoints.MapControllerRoute(
                                                              name: "default",
                                                              pattern: "{controller}/{action=Index}/{id?}");
                             });

            app.UseSpa(spa =>
                       {
                           spa.Options.SourcePath = "rmt";

                           if (env.IsDevelopment())
                           {
                               spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                           }
                       });
        }
    }
}