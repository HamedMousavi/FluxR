using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoFlux.Domain;
using PhotoFlux.Flickr;
using PhotoFlux.Flickr.Models.Mappers;
using PhotoFlux.Google;
using PhotoFlux.Models;

namespace PhotoFlux
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetSection("Flickr").Get<FlickrSettings>());
            services.AddSingleton(Configuration.GetSection("Google").Get<GoogleSettings>());

            services.AddScoped<IPhotoStore, FlickrApi>();
            services.AddScoped<IMapper<FlickrPhotoDetails, PhotoMetadata>, PhotoMetadataMapper>();
            services.AddScoped<IMapper<PagedFlickrPhotos, PagedPhotoSearchResult>, PhotoSearchResultMapper>();
            services.AddScoped<IPhotoStore, FlickrApi>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
