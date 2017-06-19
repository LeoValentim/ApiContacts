using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiContacts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace ApiContacts
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc();
            /*services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigins"));
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllMethods"));
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllHeaders"));
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowCredentials"));
            });*/
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
