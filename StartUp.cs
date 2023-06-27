using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Data;
using System.Text.Json.Serialization;

namespace StarWars
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



            services.AddDbContext<StarWarsContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("StarWarsContext") ?? throw new InvalidOperationException("Connection string 'StarWarsContext' not found.")));
            
            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "StarWarsCharacters",
                    Version = "v1"
                });
            });



            //services.AddScoped<ISortByNameOrStartDate, SortByNameOrStartDate>();

            using (var context = services.BuildServiceProvider())
            {
                var scope = context.CreateScope().ServiceProvider;
                SeedData.SeedMovies.Initialize(scope);
                SeedData.SeedCharacters.Initialize(scope);
            }

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWarsCharacters v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

