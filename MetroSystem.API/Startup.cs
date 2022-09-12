﻿using MassTransit;
using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Commands;
using MetroSystem.Domain.Consumers;
using MetroSystem.Domain.Events;
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
            });
           // services.AddSingleton<IEventRepository<BasketAggregate, BasketAggregateState>, 
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
