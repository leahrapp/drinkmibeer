using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DrinkMiBeer.Core.Factories;
using DrinkMiBeer.Core.Interfaces;
using DrinkMiBeer.Core.Interfaces.RepositoryInterfaces;
using DrinkMiBeer.Infrastructure.Data;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Services;
using DrinkMiBeer.Core.Entities;
using DrinkMiBeer.Core.Mappers;
using DrinkMiBeer.Infrastructure.Data.Repository;
namespace DrinkMiBeer.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        // private readonly IConfiguration _config;
        private static DocumentClient client;
        public Startup(IConfiguration config)
        {

            _config = config;
        }


        public IConfiguration _config { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            //This is where we add the dependancy injection Yeah! 
            // services.AddTransient<>
            //I might be able to delete this whole thing 
            //  services.AddSingleton<IConfiguration>(_config);
            // services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRepoWrapper, RepoWrapper>();
            // services.AddScoped<IBeerApiToBreweryMapper<BeerApiJTO, Brewery>, BeerApiJtoToBreweryMapper>();
            services.AddSingleton<IBeerApiUrlBuilder, BeerApiUrlBuilder>();
            services.AddSingleton<IBuildBreweryDb, BuildBreweryDb>();

            services.AddSingleton<IMapBoxApiUrlBuilder, MapBoxApiUrlBuilder>();
            services.AddSingleton<IPublicApiService<BeerApiJTO>, PublicApiService<BeerApiJTO>>();

            services.AddSingleton<IPublicApiService<MapBoxJTO>, PublicApiService<MapBoxJTO>>();
            // services.AddTransient<IUrlBuilder, GeoLocatorApiUrlBuilder>();

            //entityframeworkcore was removed when I installed the .cosmo extension. you'll have to reinstall it
            //Install-Package Microsoft.EntityFrameworkCore.Cosmos -Version 3.0.0-preview.19074.3

            services.AddDbContext<RepositoryContext>(options => options.UseCosmos(
                _config.GetSection("CosmoDb").GetSection("Endpoint").Value.ToString(),
            _config.GetSection("CosmoDb").GetSection("Key").Value.ToString(),
            _config.GetSection("CosmoDb").GetSection("Collection").Value.ToString()
                )
                );
            //     services.AddDbContext<DrinkMiBeerDbContext>(options =>
            //options.UseSqlServer(_config.GetConnectionString("BeerDB")));
            //     services.AddDbContext<RepositoryContext>(options =>
            //options.UseSqlServer(_config.GetConnectionString("BeerDB")));

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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc();
            // InitializeDB();
        }
        //do this some other time
        ///// <summary>
        ///// Take this out to it's own admin section. Also break up the app config json
        ///// </summary>
        ///// 

        private void InitializeDB()
        {
            var bleh = _config.GetSection("CosmoDb");
            var key = _config.GetSection("CosmoDb").GetSection("Key").Value.ToString();

            var endpoint = _config.GetSection("CosmoDb").GetSection("Endpoint").Value.ToString();
            client = new DocumentClient(new Uri(endpoint), key);
            CreateDatabaseIfNotExistsAsync("CosmoDb").Wait();
            CreateCollectionIfNotExistsAsync("CosmoDb", "BreweryInfo").Wait();


        }
        private static async Task CreateCollectionIfNotExistsAsync(string db, string coll)
        {


            try
            {

                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(db, coll));

            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(db),
                        new DocumentCollection { Id = coll },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }


        private static async Task CreateDatabaseIfNotExistsAsync(string db)
        {

            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(db));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = db });
                }
                else
                {
                    throw;
                }
            }
        }
    }

}

