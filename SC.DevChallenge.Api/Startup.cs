using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SC.DevChallenge.Storage.Context;
using SC.DevChallenge.Storage.Shared.Repositories;
using SC.DevChallenge.Storage.Shared.Repositories.Interfaces;
using SC.DevChallenge.Services;
using SC.DevChallenge.Services.Interfaces;

namespace SC.DevChallenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DevChallengeContext>(options =>
                options.UseInMemoryDatabase(databaseName: "DevChallengeDb"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SC.DevChallenge.Api", Version = "v1" })
            );

            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ICSVParseService, CSVParseService>();
            services.AddTransient<ITransactionService, TransactionsService>();


            var sp = services.BuildServiceProvider();
            var csvParseServive = sp.GetService<ICSVParseService>();
            csvParseServive.Parse();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SC.DevChallenge.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
