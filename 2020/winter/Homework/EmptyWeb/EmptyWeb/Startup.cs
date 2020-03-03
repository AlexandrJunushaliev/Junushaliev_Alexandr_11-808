using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmptyWeb
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IMessageSender, EmailMessageSender>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", new HomeController().GetForm);
				endpoints.MapGet("/Posts", new HomeController().GetPosts);
				endpoints.MapGet("/Posts/DeletePost", new HomeController().DeletePost);
				endpoints.MapGet("/Posts/OpenPost", new HomeController().OpenPost);
				endpoints.MapGet("/Files/{FileName}", new HomeController().FileProvider);
				endpoints.MapPost("/Home/AddEntry", new HomeController().AddEntry);
				endpoints.MapPost("/Posts/rewritePost", new HomeController().RewritePost);
			});
			
		}
	}
}
