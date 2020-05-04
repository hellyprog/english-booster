using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Newtonsoft.Json;
using EnglishBooster.API.DbAccess;
using EnglishBooster.API.BusinessLogic.Interfaces;
using EnglishBooster.API.BusinessLogic;
using EnglishBooster.API.BusinessLogic.Services;
using EnglishBooster.API.DbAccess.Mappings;

namespace EnglishBooster.API
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
			services.AddMvc();
			services.AddControllers().AddNewtonsoftJson();
			
			services.AddTransient<ITelegramBotClient, TelegramBotClient>(s =>
			{
				var token = Configuration["BotToken"];
				return new TelegramBotClient(token);
			});

			services.AddTransient<IWordRepository, WordRepository>(c =>
			{
				var connectionString = Configuration["DatabaseSettings:ConnectionString"];
				var dbName = Configuration["DatabaseSettings:DatabaseName"];
				return new WordRepository(connectionString, dbName);
			});

			services.AddTransient<ICommandFactory, CommandFactory>();
			services.AddTransient<IWordService, WordService>();

			ConfigureMapping();
		}

		public void ConfigureMapping()
		{
			WordMapping.Register();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});


		}
	}
}
