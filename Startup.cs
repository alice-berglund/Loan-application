using LoanApplicationAPI.Domain.LoanDecisionRules;
using LoanApplicationAPI.Handlers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace LoanApplicationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LoanApplicationDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("LoanApplication");
                options.UseSqlServer(connectionString);
            }).AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services
                .AddScoped<ILoanDecisionFactory, LoanDecisionFactory>()
                .AddScoped<ICreateLoanApplicationHandler, CreateLoanApplicationHandler>()
                .AddScoped<IUpdateLoanApplicationHandler, UpdateLoanApplicationHandler>()
                .AddScoped<ILoadLoanApplicationDecisionHandler, LoadLoanApplicationDecisionHandler>()
                .AddScoped<IDeleteLoanApplicationHandler, DeleteLoanApplicationHandler>();

            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
