using MassTransit;
using MetroSystem.API.Commands;
using MetroSystem.API.Consumers;
using MetroSystem.API.Stores;
using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Events;
using MetroSystem.Domain.Models;
using MetroSystem.Infrastructure.Context;
using MetroSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace MetroSystem.API
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
            services.AddControllers();
            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    //if (!context.ModelState.IsValid)
                    //{
                    //    LoggerExtensions.LogInformation(context);
                    //}
                    return new BadRequestObjectResult(context.ModelState);
                };
            });
            services.AddMediator(x =>
            {
                
                x.AddRequestClient<CreateBasketCommand>();
                x.AddConsumer<CreateBasketCommandConsumer>();
                x.AddRequestClient<BasketCreatedEvent>();
                x.AddConsumer<CreateBasketEventConsumer>();
                x.AddRequestClient<UpdateBaskeCommand>();
                x.AddConsumer<UpdateBasketCommandConsumer>();
            });

           
            services.AddSingleton<DapperContext>();
            
            services.AddSingleton<IEventRepository<BasketAggregate, BasketAggregateState>, BasketEventRepository>();
            services.AddSingleton<IAggregateFactory<BasketAggregate, BasketAggregateState>, BasketAggregateFactory>();
            services.AddSingleton<IBasketEventStore, BasketEventStore>();
            services.AddSingleton<IBasketEventRepository, BasketEventRepository>();
            services.AddSingleton<IBasketRepository, BasketRepository>();
            services.AddSingleton<IBasketAggregateFactory, BasketAggregateFactory>();
        }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
           
            app.UseRouting();
          

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
          
        }
    }
}
